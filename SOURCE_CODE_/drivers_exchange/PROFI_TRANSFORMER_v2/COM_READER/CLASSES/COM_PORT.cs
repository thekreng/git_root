using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COM_READER.CLASSES
{
    class COM_PORT : IDisposable
    {
        /// <summary>
        /// Класс работы с последовательным портом
        /// </summary>
        //public class SerialPort : IDisposable
       // {
            //--------------------------------------------------------------------------
            //Construction, Destruction
            //--------------------------------------------------------------------------
            #region Construction, Destruction
            /// <summary>
            /// Оболочка для работы с СОМ-портом
            /// </summary>
            /// <param name="comNum">Номер СОМ-порта</param>
            /// <param name="baudRate">Скорость</param>
            public COM_PORT(byte comNum, int baudRate)
            {
                this.comNum = comNum;
                serialPort = new System.IO.Ports.SerialPort("COM" + comNum.ToString(), baudRate);
                serialPort.Open();
                thread = new System.Threading.Thread(ThreadFn);
                thread.Start();
            }

            /// <summary>
            /// Очистка ресурсов
            /// </summary>
            public void Dispose()
            {
                DisposeImpl(true);
            }

            /// <summary>
            /// Finalizer
            /// </summary>
            ~COM_PORT()
            {
                DisposeImpl(false);
            }

            private void DisposeImpl(bool manualDispose)
            {
                if (manualDispose)
                {
                    if (thread != null)
                        thread.Abort();
                    if (serialPort != null)
                        serialPort.Dispose();
                }
            }
            #endregion Construction, Destruction

            //--------------------------------------------------------------------------
            //Public Interface
            //--------------------------------------------------------------------------
            #region Public Interface
            /// <summary>
            /// Отправить данные
            /// </summary>
            /// <param name="data">Массив данных</param>
            /// <exception cref="Exception">Генерируется, если при работе с последовательным портом
            /// возникнет исключение</exception>
            public void SendData(Byte[] data)
            {
                serialPort.Write(data, 0, data.Length);
            }

            /// <summary>
            /// Текущий номер СОМ-порта
            /// </summary>
            public Byte ComNum
            {
                get { return comNum; }
                set
                {
                    if (comNum != value)
                    {
                        comNum = value;
                        serialPort.Close();
                        serialPort.PortName = "COM" + value.ToString();
                    }
                }
            }

            /// <summary>
            /// Скорость передачи данных
            /// </summary>
            public int BaudRate
            {
                get { return serialPort.BaudRate; }
                set { serialPort.BaudRate = value; }
            }
            /// <summary>
            /// Состояние линии Dtr
            /// </summary>
            public bool DtrEnable
            {
                get { return serialPort.DtrEnable; }
                set { serialPort.DtrEnable = value; }
            }
            /// <summary>
            /// Состояние линии Rts
            /// </summary>
            public bool RtsEnable
            {
                get { return serialPort.RtsEnable; }
                set { serialPort.RtsEnable = value; }
            }

            /// <summary>
            /// Делегат приема байта
            /// </summary>
            /// <param name="data">Принятый байт данных</param>
            public delegate void OnByteReceived(Byte data);

            /// <summary>
            /// Событие приема байт
            /// </summary>
            public event OnByteReceived ByteReceived;
            #endregion Public Interface

            //--------------------------------------------------------------------------
            //Private Member Functions
            //--------------------------------------------------------------------------
            #region Private Member Functions
            //Обработка принятого байта
            private void OnReceiveByte(Byte data)
            {
                //Если на событие приема байт кто-то подписан, то отправляю ему байт
                if (ByteReceived != null)
                    ByteReceived(data);
            }
            //Функция чтения данных в новом потоке
            private void ThreadFn(object obj)
            {
                //создаю входной буффер. Сюда будут писаться данные из последовательного порта
                Byte[] inputBuffer = new Byte[inputBufferSize];
                while (true)
                {

                    try
                    {
                        //получаю количество доступных байт
                        int availibleBytes = serialPort.BytesToRead;
                        if (availibleBytes > 0)
                        {
                            int bytesToRead = availibleBytes < inputBufferSize ? availibleBytes : inputBufferSize;
                            int readedBytes = serialPort.Read(inputBuffer, 0, bytesToRead);
                            for (int i = 0; i < readedBytes; i++)
                                OnReceiveByte(inputBuffer[i]);
                        }
                        System.Threading.Thread.Sleep(1);
                    }
                    catch (System.Threading.ThreadAbortException)
                    {
                        break;
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.Assert(false, e.Message);
                    }
                }
            }
            #endregion Private Member Functions

            //--------------------------------------------------------------------------
            //Private Data Members
            //--------------------------------------------------------------------------
            #region Private Data Members
            /// <summary>
            /// Номер СОМ-порта
            /// </summary>
            private Byte comNum;
            /// <summary>
            /// Последовательный порт
            /// </summary>
            private System.IO.Ports.SerialPort serialPort;
            /// <summary>
            /// Поток. Нужен, т.к. данные читаются в новом потоке
            /// </summary>
            private System.Threading.Thread thread;
            /// <summary>
            /// Максимальный размер входного буффер
            /// </summary>
            private const int inputBufferSize = 1024;

            #endregion Private Data Members
        //}//class RS232
    }
}
