using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.IO;
using System.Timers;
using System.Threading;
using System.Threading.Tasks;

namespace COM_READER
{
    public partial class Form1 : Form
    {
        static bool _continue = true;
        static SerialPort _serialPortCPU = new SerialPort();
        
        static SerialPort _serialPortSLAVE = new SerialPort();

        public Form1()
        {
            Thread readThread = new Thread(Read);
            InitializeComponent();
            _serialPortCPU.WriteTimeout = 1000000;
            _serialPortSLAVE.WriteTimeout = 1000000;
            foreach (string s in SerialPort.GetPortNames())
            {
                listBoxAvalPorts.Items.Add(s);
            }

            foreach (string s in Enum.GetNames(typeof(Parity)))
            {
                listBoAvParity.Items.Add(s);
            }

            foreach (string s in Enum.GetNames(typeof(StopBits)))
            {
                listBoxStopBits.Items.Add(s);
            }

            foreach (string s in Enum.GetNames(typeof(Handshake)))
            {
                listBoxEndHandshake.Items.Add(s);
            }
            listBoxBaudRate.SetSelected(0, true);
            listBoAvParity.SetSelected(2, true);
            listBoxDataBits.SetSelected(3, true);
            listBoxBaudRate.SetSelected(1, true);
            listBoxStopBits.SetSelected(1, true);
            listBoxEndHandshake.SetSelected(0, true);
            // Set the read/write timeouts
            _serialPortCPU.ReadTimeout = Convert.ToInt32(textBoxReadTime.Text);
            _serialPortCPU.WriteTimeout = Convert.ToInt32(textBoxWrTime.Text);
            _serialPortCPU.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandlerCPU);


            _serialPortSLAVE.ReadTimeout = Convert.ToInt32(textBoxReadTime.Text);
            _serialPortSLAVE.WriteTimeout = Convert.ToInt32(textBoxWrTime.Text);
            _serialPortSLAVE.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandlerSLAVE);

            this.WindowState = FormWindowState.Maximized;
            //txtSearch.TextChanged += new System.EventHandler(textBoxTextChanged);
            cmbSearch.TextChanged += new System.EventHandler(cmbSearchChanged);
            comboBox1.TextChanged += new System.EventHandler(cmbSearchChangedHex);
        }
        string portName;
        string baudRate;
        int dataBits;
        Handshake handshake = new Handshake();
        Parity parity = new Parity();
        StopBits stopBits = new StopBits();

        bool first_flag = false;


        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (btnOpen.Text == "OPEN SESSION" ||  btnOpen.Text == "OPEN SLAVE SESSION")
            {
                if (listBoxAvalPorts.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Oh no!!! :( You don't select PORT NUMBER");
                }
                else
                {
                    portName = listBoxAvalPorts.SelectedItem.ToString();
                    if (listBoxBaudRate.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("Oh no!!! :( You don't select BAUD RATE");
                    }
                    else
                    {
                        baudRate = listBoxBaudRate.SelectedItem.ToString();
                        if (listBoAvParity.SelectedItems.Count == 0)
                        {
                            MessageBox.Show("Oh no!!! :( You don't select PARITY");
                        }
                        else
                        {
                            parity = (Parity)Enum.Parse(typeof(Parity), listBoAvParity.SelectedItem.ToString(), true);
                            if (listBoxDataBits.SelectedItems.Count == 0)
                            {
                                MessageBox.Show("Oh no!!! :( You don't select DATA BITS");
                            }
                            else
                            {
                                dataBits = int.Parse(listBoxDataBits.SelectedItem.ToString().ToUpperInvariant());
                                if (listBoxStopBits.SelectedItems.Count == 0)
                                {
                                    MessageBox.Show("Oh no!!! :( You don't select STOP BIT");
                                }
                                else
                                {
                                    stopBits = (StopBits)Enum.Parse(typeof(StopBits), listBoxStopBits.SelectedItem.ToString(), true);
                                    if (listBoxEndHandshake.SelectedItems.Count == 0)
                                    {
                                        MessageBox.Show("Oh no!!! :( You don't select HANDSHAKE");
                                    }
                                    else
                                    {
                                        if (first_flag == false)
                                        {
                                            handshake = (Handshake)Enum.Parse(typeof(Handshake), listBoxEndHandshake.SelectedItem.ToString(), true);

                                            _serialPortCPU.PortName = portName;
                                            _serialPortCPU.BaudRate = Convert.ToInt32(baudRate);
                                            _serialPortCPU.Parity = parity;
                                            _serialPortCPU.DataBits = dataBits;
                                            _serialPortCPU.StopBits = stopBits;
                                            _serialPortCPU.Handshake = handshake;
                                            first_flag = true;
                                            try
                                            {
                                                _serialPortCPU.Open();
                                                btnOpen.Text = "OPEN SLAVE SESSION";
                                            }
                                            catch (Exception ex)
                                            {
                                                listBoxErr.Invoke(new MethodInvoker(delegate()
                                                {
                                                    listBoxErr.Items.Add(ex.ToString());
                                                }
                                                                       ));
                                            }
                                            
                                            lblStatus.Text = "IS ONLINE IN CPU";
                                        }
                                        else
                                        {
                                            handshake = (Handshake)Enum.Parse(typeof(Handshake), listBoxEndHandshake.SelectedItem.ToString(), true);

                                            _serialPortSLAVE.PortName = portName;
                                            _serialPortSLAVE.BaudRate = Convert.ToInt32(baudRate);
                                            _serialPortSLAVE.Parity = parity;
                                            _serialPortSLAVE.DataBits = dataBits;
                                            _serialPortSLAVE.StopBits = stopBits;
                                            _serialPortSLAVE.Handshake = handshake;
                                            try
                                            {
                                                _serialPortSLAVE.Open();
                                                btnOpen.Text = "OPEN SLAVE SESSION";
                                            }
                                            catch (Exception ex)
                                            {
                                                listBoxErr.Invoke(new MethodInvoker(delegate()
                                                {
                                                    listBoxErr.Items.Add(ex.ToString());
                                                }
                                                                       ));
                                            }

                                            lblStatus.Text = "IS ONLINE IN EXCHENGE MODE";


                                            _continue = true;
                                            

                                            tm1.Start();
                                        }
                                        
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                _continue = false;
                _serialPortCPU.Close();
                _serialPortSLAVE.Close();
                
                elapsed = 0;
                start_interval = 0;
                tm1.Stop();
                lbltime.Text = "";
                btnOpen.Text = "";
                
            }
        }
       #region STRUCTS 
        enum STATUS : byte
            {
	            NO_ERR = 0x00,		// OK. No Errors in frame
	            WRONG_SD = 0x01,	// Incorrect Frame start byte
	            WRONG_FCS = 0x02,	// Incorrect CRC
	            WRONG_ED = 0x04,	// Incorrect end byte (almost always must be 0x16)
	            LE_ERR = 0x08,		// LE!=LEr (different 2nd and 3rd bytes for SD= 0x68)
	            SD2_ERR = 0x10,	    // different SD2 (byte 1 and 4)
            }
        enum FRAME_TYPE : byte
            {
	            FRAME_TYPE_SD1 = 0x10,
	            FRAME_TYPE_SD2 = 0x68,
	            FRAME_TYPE_SD3 = 0xA2,
	            FRAME_TYPE_SD4 = 0xDC,
	            FRAME_TYPE_SC = 0xE5
            }


#endregion 
#region INITIAL_PARSE_FUNCS
     unsafe public static byte checksum(byte *ptr, int sz) 
        {
	        byte chk = 0;
	        while (sz-- != 0)
		    chk += *ptr++;
	        return chk;
        }
     public static bool frameType(byte fc) // Определяем запрос или ответ
        {
         
         bool result = false;
         if (fc > 0x40) //Побитовое и введен ли 6 бит 
         {
             result = true;
         }
         
         return result;
                //((0x40)&(fc)) ? true : false;//Побитовое и введен ли 6 бит 
        }
     public static bool fcb(byte fc)
        {
         bool result = false;
         if (fc>0x20)
         {
             result = true;      
         }
           return result;
        }
     public static bool fcv(byte fc)
     {
         bool result = false;
	     if (fc>0x10)
         {
             result = true;
         }
         return result;  
    }
     string stationType(byte fc)//Передача по ССЫЛКЕ потока (!!!Не стал делать (ref Stream os),  - времени не хватило разобратьс с System.IO.Stream)ввода вывода (иначе копия потока)   тип станции
    
{
    string result;
	switch (fc&(0x30))
	{
	case 0x10:
		result = "(active station not ready) ";
		break;

	case 0x20:
        result = "(active station for token ring) ";
		break;

	case 0x18:
        result = "(active station is  token ring) ";
		break;

	default:
        result = "(passive station) ";
		break;
	}

	return result;
}
     public static string displayFrameType(byte fc)// Парсинг бита для типа пакета запрос или ответ 
{
    string frame_type;
	bool ft,fcb_,fcv_;
	ft = frameType(fc);// 0 или 1 Ответ/Запрос
	fcb_ = fcb(fc);
	fcv_ = fcv(fc);
    if (ft == true)
    {
        frame_type = "Request;";
    }
    else
    {
        frame_type = "Response;";
    }

	// FCB=Frame Control Bit (inverted inition bit) and FCV=Frame Count Bit valid (1 = other FCB is valid)
   if (ft) frame_type += "FCB = " + fcb_ + " FCV = " + fcv_;
    return frame_type;
}
     unsafe public static bool areSapsPresented(byte *da)//byte data unit первый 2 байта могут быть специальными saps ....в данных не может быть 3E...
{
    bool result = false;
	byte *daIn = da;
    if (*daIn > 127)
    {
        result = true;
    }
    return result;
	//return (((*ssap) & 0x3E)) ? true : false;//  тернарная нет явного преобразования в шарпах int=>bool
}
     unsafe public static string displaySaps(byte *da , bool ft)//
{
    string result;
    byte *dsap = da+2;
	byte *ssap = da+3;
    if (!(areSapsPresented(da))) { result = "No SAPs (data tranfer)"; return result; }
    result = "SAPs (dec) " + Convert.ToDecimal(*ssap); //   CAST to DEC для вывода
	result += " DSAPs (dec) "; 
    result += Convert.ToDecimal(* dsap) + " ";
    return result;
}       
     unsafe public static string displayArrow(bool ft)
        {
         string result = "";
         if (ft) { result = "->"; }
         else { result = "<-"; }
         return result;
        }
     public static string displayFunction(byte fc, bool ft)//Расшифровываем фунцию старший бит, 7 бит запрос ответ, 5,6 fcb , 00001111
{
    string result;
	if (ft)
	{
		switch (fc & 0x0F)
		{

		case 0x03:
			result = "SDA (Send Data with Acknowledge low) ";
			break;

		case 0x04:
            result = "SDN (Send Data with No Acknowledge low) ";
			break;

		case 0x05:
            result = "SDA (Send Data with Acknowledge high) ";
			break;

		case 0x06:
            result = "SDN (Send Data with No Acknowledge high) ";
			break;

		case 0x09:
            result = "(Request FDL status with reply) ";
			break;

		case 0x0C:
            result = "SRD (Send and Request Data low) ";
			break;

		case 0x0D:
            result = "SRD (Send and Request Data high) ";
			break;

		case 0x0E:
            result = "(Request Ident with Reply) ";
			break;

		case 0x0F:
            result = "(Request LSAP-Status with Reply) ";
			break;

		default:
            result = "Reserved ";
			break;
		}

		
		return result;
	}
		
	else
	{
		switch (fc & 0x0F)
		{

		case 0x00:
                result = "OK (ACK positive) ";
			break;

		case 0x01:
            result = "UE (ACK negative FDL, FMA1/2-User Error) ";
			break;

		case 0x02:
            result = "RR (ACK negative, no resource for send data) ";
			break;

		case 0x03:
            result = "RS (ACK negative, no service activated) ";
			break;

		case 0x08:
            result = "DL (Response FDL, FMA1/2-Data low send data OK) ";
			break;

		case 0x09:
            result = "NR (ACK negative, No Response FDL, FMA1/2-Data, send data OK) ";
			break;

		case 0x0A:
            result = "DH (Response FDL-data high, send data OK) ";
			break;

		case 0x0C:
            result = "RDL (Response FDL-data low, no resource for send data) ";
			break;

		case 0x0D:
            result = "RDH (Response FDL-data high, no resource for send data) ";
			break;

		default:
            result = "Reserved ";
			break;
		}
	}
	return result;// на всякий случай
}
     public string displayErrors(byte ec)
        {
            string result = "";
	        if (!Convert.ToBoolean(ec)) result = "OK (No Errors); ";
	        else
	        {
               // MessageBox.Show(ec.ToString() + " " + (byte)STATUS.SD2_ERR + " " + (byte)STATUS.WRONG_FCS + " " + (byte)STATUS.WRONG_SD + " " + (byte)STATUS.WRONG_ED + " " + (byte)STATUS.LE_ERR);
                if (Convert.ToBoolean((ec&(byte)STATUS.WRONG_SD)) == true) result += "WRONG_SD; ";
                if (Convert.ToBoolean((ec & (byte)STATUS.WRONG_FCS)) == true) result += "WRONG_FCS; ";
                if (Convert.ToBoolean((ec & (byte)STATUS.WRONG_ED)) == true) result += "WRONG_ED; ";
                if (Convert.ToBoolean((ec & (byte)STATUS.LE_ERR)) == true) result += "LE_ERR; ";
                if (Convert.ToBoolean((ec & (byte)STATUS.SD2_ERR)) == true) result += "SD2_ERR; ";                
	        }

            return result;
        }
        #endregion

        void ColorOut(string input, string type, PB_Base PB_IN)
        {

            if (PB_IN != null)
            {
                ColorOutUN("Time: " + System.DateTime.Now.ToLongTimeString()+"."+ System.DateTime.Now.Second + "."+ System.DateTime.Now.Millisecond + input, type);
                ColorOutResponseSsaps("Time: " + System.DateTime.Now.ToLongTimeString() + "." + System.DateTime.Now.Second + "." + System.DateTime.Now.Millisecond + input, type, PB_IN.SSAPS);
                ColorOutReqestSsaps("Time: " + System.DateTime.Now.ToLongTimeString() + "." + System.DateTime.Now.Second + "." + System.DateTime.Now.Millisecond + input, type, PB_IN.SSAPS);
                ColorOutDC("Time: " + System.DateTime.Now.ToLongTimeString() + "." + System.DateTime.Now.Second + "." + System.DateTime.Now.Millisecond + input, type);
            }
            else
            {
                ColorOutUN(input, type);
                ColorOutResponseSsaps(input, type, "");
                ColorOutReqestSsaps(input, type, "");
                ColorOutDC(input, type);
            }

        
                        

           
        }

        private void ColorOutDC(string input, string type)
        {
            if (type == "DC")
            {

                listViewHewColor.Invoke(new MethodInvoker(delegate()
                {
                    listViewHewColor.Items.Add(input);
                    listViewHewColor.Items[HexTextPosition].BackColor = Color.Gray;
                }
            ));
                HexTextPosition++;
            }
        }
        private void ColorOutReqestSsaps(string input, string type, string ssaps)
        {
            if (type == "->" && ssaps != "No SAPs (data tranfer)" && ssaps != null)
            {

                listViewHewColor.Invoke(new MethodInvoker(delegate()
                {
                    listViewHewColor.Items.Add(input);
                    listViewHewColor.Items[HexTextPosition].BackColor = Color.Blue;
                }
            ));
                HexTextPosition++;
            }
            else if (type == "->")
            {
                listViewHewColor.Invoke(new MethodInvoker(delegate()
                {
                    listViewHewColor.Items.Add(input);
                    listViewHewColor.Items[HexTextPosition].BackColor = Color.Green;
                }
                                                                  ));
                HexTextPosition++;
            }
        }
        private void ColorOutResponseSsaps(string input, string type, string ssaps)
        {
            if (type == "<-" && ssaps != "No SAPs (data tranfer)" && ssaps != null)
            {
                listViewHewColor.Invoke(new MethodInvoker(delegate()
                {
                    listViewHewColor.Items.Add(input);
                    listViewHewColor.Items[HexTextPosition].BackColor = Color.Blue;
                }
                                                                  ));
                HexTextPosition++;
            }
            else if (type == "<-")
            {
                listViewHewColor.Invoke(new MethodInvoker(delegate()
                {
                    listViewHewColor.Items.Add(input);
                    listViewHewColor.Items[HexTextPosition].BackColor = Color.Yellow;
                }
                                                                  ));
                HexTextPosition++;
            }
        }
        private void ColorOutUN(string input, string type)
        {
            if (type == "UN")
            {
                listViewHewColor.Invoke(new MethodInvoker(delegate()
                {
                    listViewHewColor.Items.Add(input);
                    listViewHewColor.Items[HexTextPosition].BackColor = Color.Red;
                }
                                                              ));
                HexTextPosition++;

            }
        }


#region CLASSES

public unsafe class PB_Base{//BASIC CLASS
        public PB_Base() { }
        public PB_Base(ref byte[] ptr, int l) { *buffer = ptr[0]; len = l; }        
            
		//public PB_Base(ref PB_Base other) : this(){buffer(other.buffer)     buffer(other.buffer); len(other.len), retCode(other.retCode)}// конструктор копирования будешь помещать вектор (List)
		  ~PB_Base() {}// базовый класс деструктор виртуальный === > чтоб весь объект удалить определили и объявили

        public virtual string display() { return OUT_STR; }// указатели на базовые классы =   0   - чиста виртуальная - класс базовый === функция обязательно должна быть определена в потомках
        public byte getRetCode()  { return retCode; }// защитили данные
        public void setRetCode(byte code) { retCode = code; }//
        public byte *getBuffer() { return buffer; }// констатная функция (нет в шарпах).. не буду менять данные объекты
        public int  getLen() { return len; }
        public virtual void decode() { return; }// по умолчаниб везде есть, но может быть переопределена (сокрыта)
        public virtual string GetDirectType() { return DirectType; }
        public virtual void ColorPrint() { }
        public virtual string GetFCtype() { return DirectType; }
        public byte *buffer{get;set;}
    public int len{get;set;}
    public byte retCode { get; set; }
    private string OUT_STR { get; set; }
    public string DirectType { get; set; }
    public string SSAPS { get; set; }
    public string FCtype { get; set; }
    //public byte[] DATA_ARRAY { get; set; }
    public byte fcs_withoutData { get; set; }
        }



public unsafe class PB_Default :  PB_Base{
public PB_Default(){}
public PB_Default(ref byte[] p, int l) { bufer = p; sz = l; } // передача явно в контруктор базового класса список инициализация 

	public override void decode()
	{
		setRetCode((byte)STATUS.WRONG_SD);// уст неправильный бит
		//return;
	}

	public override string display()
	{
        OUT_STR = "";
        OUT_STR = "Incorrect Frame start byte";
        return OUT_STR;
	}
    
    public string OUT_STR;
    public int sz; 
    public byte[] bufer;
};

public unsafe class PB_SC: PB_Base{

    public PB_SC(ref byte[] p, int l) { bufer = p; sz = l; }
	public override string display()
	{
        OUT_STR = "";
        OUT_STR = "Short acknowledge message";
        return OUT_STR;
	}

    public string OUT_STR; 
    public byte[] bufer;
    public int sz;
};

public unsafe class PB_SD4 : PB_Base{

    public PB_SD4(ref byte[] p, int l){ bufer = p; sz = l; }

	public override void decode()
	{

        fixed (byte* Pbuf = bufer)////ВРоде как тут и не надо(напрямую доступ)
        {
            da = bufer[2];
            sa = bufer[1];
            
        }
	}
	public override string display()
	{
        OUT_STR = "";
        OUT_STR = "Token transfer message: " + "ADDR " + da + "->" + sa;
        return OUT_STR;
	}
    public override string GetDirectType()
    {
        string result;
        result = "->";
        return result;
    }

        private	byte da = 0, sa = 0;
        public string OUT_STR;
        public byte[] bufer;
        public int sz;
};

public unsafe class PB_SD2 : PB_Base
        {
    public unsafe PB_SD2(ref byte[] p, int l) { bufer = p; sz = l; } 
            public override void decode()
            {
                fixed (byte* Pbuf = bufer)
                {
                    int len = sz;

                    da = bufer[4];
                    sa = bufer[5];
                    le = bufer[1];
                    fc = bufer[6];
                    
                    fsc = bufer[le + 4];
                    ft = frameType(bufer[6]);
                    if (bufer[3] != bufer[0]) setRetCode((byte)(getRetCode() | (byte)STATUS.SD2_ERR));
                    if (bufer[1] != bufer[2]) setRetCode((byte)(getRetCode() | (byte)STATUS.LE_ERR));
                    if (bufer[len - 1] != 0x16) setRetCode((byte)(getRetCode() | (byte)STATUS.WRONG_ED));
                    
                    if (fsc != checksum(Pbuf + 4, le)) 
                        setRetCode((byte)(getRetCode() | (byte)STATUS.WRONG_FCS));
                    bool SSAPS = areSapsPresented(Pbuf + 4);
                    if (SSAPS == true)
                    { 
                        //dataLen = le - 5;
                        da -= 0x80;
                        sa -= 0x80;
                        dataLen = le - 5;
                        dataBegin = Convert.ToByte(9);
                    }
                    else
                    { 
                        dataLen = le-3;
                        dataBegin = Convert.ToByte(7);
                    }
                    //dataLen = areSapsPresented(Pbuf + 5) ? (le - 5) : (le - 3);
                    

                    ed = bufer[len - 1];
                    try
                    {
                        fcs_withoutData = checksum(Pbuf + 4, le - dataLen);
                    }
                    catch { }
                }
            }
            public override string display()
            {
                OUT_STR = "";
                OUT_STR += "Data transfer:";

                fixed (byte* Pbuf = bufer)
                {
                    int len = sz;
                    if (ft == true)
                    {
                        OUT_STR = "ADDR " + Convert.ToDecimal(sa) + displayArrow(ft);
                        OUT_STR += Convert.ToDecimal(da);
                    }
                    else
                    {
                        OUT_STR = "ADDR " + Convert.ToDecimal(da) + displayArrow(ft);
                        OUT_STR += Convert.ToDecimal(sa);
                    }
                    OUT_STR += " frame_type = " + displayFrameType(fc);
                    OUT_STR += " function=" + displayFunction(fc, ft);
                    SSAPS = displaySaps(Pbuf + 5, ft);
                    OUT_STR += SSAPS;
                    OUT_STR += " dataLen = " + dataLen + " " + " DATA = ";
                    byte countDATA = 0;
                    //DATA_ARRAY = new byte[dataLen];
                    try
                    {
                        for (byte i = dataBegin; i < dataBegin + dataLen; ++i)
                        {
                            //if (bufer[i] < 16) 
                            OUT_STR += "0" + bufer[i].ToString("X");
                            //DATA_ARRAY[countDATA] = bufer[i];
                            countDATA++;
                        }
                    }
                    catch { }

                    OUT_STR += " CRC = " + fsc.ToString("X");
                    OUT_STR += " End = " + ed.ToString("X");
                }

                return OUT_STR;
                    }
            public override string GetDirectType()
            {
                string result;
                result = displayArrow(ft);
                return result;
            }

            public override string GetFCtype()
            {
                return displayFunction(fc, ft);
            }


            public byte da = 0, sa = 0, le = 0, fsc = 0,  dataBegin = 0 , ed = 0;
            private byte fc = 0;
            public bool ft = false;
            public int dataLen = 0;
            public byte[] bufer;
            public int sz;
            public string OUT_STR;
        };

public unsafe class PB_SD1 : PB_Base {
    public PB_SD1(ref byte[] p, int l){ bufer = p; sz = l; }

         public override void decode()
        {
            fixed (byte* Pbuf = bufer)
            {
                int len = sz;
                da = bufer[1];
                sa = bufer[2];
                fc = bufer[3];
                fsc = bufer[4];
                ft = frameType(bufer[3]);
                if (bufer[len - 1] != 0x16) setRetCode((byte)(getRetCode() | (byte)STATUS.WRONG_ED));
                
                if (fsc != checksum(Pbuf + 1, 3)) 
                    setRetCode((byte)(getRetCode() | (byte)STATUS.WRONG_FCS));
                ed = bufer[5];
            }
        }

         public override string display()
        {
            OUT_STR = "";
            OUT_STR += "Status request or acknowledge message:";
            //byte* Pbuf = getBuffer();
            //int sz = getLen();
	        if (ft == true)
            {
                OUT_STR += "ADDR " + Convert.ToDecimal(sa);
                displayArrow(ft);
                OUT_STR += da + " ";
            }
            else

            {
                OUT_STR += "ADDR " + Convert.ToDecimal(da);
                displayArrow(ft);
                OUT_STR += sa + " ";
            }
            OUT_STR += "frame_type=" + displayFrameType(fc);
            OUT_STR += " function=" + displayFunction(fc, ft) +  " ";
            OUT_STR += "CRC = " + fsc.ToString("X");
            OUT_STR += " End = " + ed.ToString("X");

            return OUT_STR;
        }
         public override string GetDirectType()
         {
             string result;
             result = displayArrow(ft);
             return result;
         }
        
        byte da = 0, sa = 0, fsc = 0, ed = 0;
        byte fc = 0;
        bool ft = false;
        public byte[] bufer;
        public int sz;
        private string OUT_STR;
        };
public unsafe class PB_SD3 : PB_Base {
    public PB_SD3(ref byte[] p, int l){ bufer = p; sz = l; }

        new void decode()
        {
            fixed (byte* Pbuf = bufer)
            {
                int len = sz;
                da = bufer[1];
                sa = bufer[2];
                fc = bufer[3];
                fsc = bufer[12];
                ft = frameType(bufer[3]);
                dataLen = 8;  // 8 bytes is max - 11 bytes minus 3 bytes: DA,SA,FC; 6 bytes in case of SAPs are presented
                dataBegin = 0;
                if (bufer[len - 1] != 0x16) setRetCode((byte)(getRetCode() | (byte)STATUS.WRONG_ED));
                
                if (fsc != checksum(Pbuf + 1, 11)) setRetCode((byte)(getRetCode() | (byte)STATUS.WRONG_FCS));
                bool SSAPS = areSapsPresented(Pbuf + 1);
                if (SSAPS == true)
                { 
                    dataLen = 6;
                    da -= 0x80;
                    sa -= 0x80;
                }
                else
                { dataLen = 8; }
                //dataLen = (areSapsPresented(Pbuf + 1)) ? (11 - 5) : (11 - 3);
                dataBegin = (byte)(1 - dataLen + 11);
                ed = bufer[len - 1];
            }
        }

        public override string display()
        {
            OUT_STR += "Data transfer (fixed length = 11 bytes):";
            fixed (byte* Pbuf = bufer)
            {
                int len = sz;
                if (ft == true)
                {
                    OUT_STR += "ADDR" + Convert.ToDecimal(sa);
                    displayArrow(ft);
                    OUT_STR += Convert.ToDecimal(da) + " ";
                }
                else
                {
                    OUT_STR += "ADDR" + Convert.ToDecimal(da);
                    displayArrow(ft);
                    OUT_STR += Convert.ToDecimal(sa) + " ";
                }

                OUT_STR += "frame_type=" + displayFrameType(fc);
                OUT_STR += " function=" + displayFunction(fc, ft) + " ";

                OUT_STR += displaySaps(Pbuf + 1, ft) + " SAPs";
                OUT_STR += "dataLen=" + dataLen + " DATA=";



                for (byte i = dataBegin; i < dataBegin + dataLen; ++i)
                {
                    if (bufer[i] < 16) OUT_STR += "0";
                    OUT_STR += bufer[i] + " ";
                }

                OUT_STR += "CRC=" + "hex" + fsc;
                OUT_STR += " End=" + "hex" + ed;
            }

            return OUT_STR;
        }
        public override string GetDirectType()
        {
            string result;
            result = displayArrow(ft);
            return result;
        }
			byte  da = 0, sa = 0,  fsc = 0, dataBegin = 0, ed = 0;
        byte fc = 0;
        bool ft = false;
        int dataLen = 0;
        public byte[] bufer;
        public int sz;
        private string OUT_STR;
        };


        

        #endregion
#region Testing DATA and func
        
       
        #endregion
        unsafe void addFrameToContainer(List<PB_Base> container, byte [] buf, int len)
        {
            PB_Base PB;
            //byte [] BYF = buf;
            switch (buf[0])
            {
                case (byte)FRAME_TYPE.FRAME_TYPE_SD2:
                    PB = new PB_SD2(ref buf, len);
                    break;

                case (byte)FRAME_TYPE.FRAME_TYPE_SC:
                    PB = new PB_SC(ref buf, len);
                    break;

                case (byte)FRAME_TYPE.FRAME_TYPE_SD4:
                    PB = new PB_SD4(ref buf, len);
                    break;

                case (byte)FRAME_TYPE.FRAME_TYPE_SD1:
                    PB = new PB_SD1(ref buf, len);
                    break;

                case (byte)FRAME_TYPE.FRAME_TYPE_SD3:
                    PB = new PB_SD3(ref buf, len);
                    break;

                default:
                    PB = new PB_Default(ref buf, len);
                    break;
            }
            
            container.Add(PB);

            return;
        }
        int ASK_068_ERR = 0;
        int ANSWER_068_ERR = 0;
        int ASK_010_ERR = 0;
        int ANSWER_010_ERR = 0;
        int UNIDENT_ERR = 0;
        int start_interval = 0;
        int time = 0;
        byte[] transfer_arr_CPU = new byte[0];
        byte[] transfer_arr_SLAVE = new byte[0];
        int prev_count = 0;
        int prev_count_SLAVE = 0;
        byte[] first = new byte[0];
        public List<PB_Base> frameVec = new List<PB_Base>();
        public static string bufferForFirstParse;
        public double getTimeSpan(DateTime time)
        {
            DateTime moment = DateTime.Now;
            long elapsedTicks = moment.Ticks - time.Ticks;
            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
            return elapsedSpan.TotalSeconds;
        }
        int elapsed = 0;
        void timer_Tick(object sender, EventArgs e)
        {
            time = Convert.ToInt32(txtTime.Text);
            elapsed = (start_interval += tm1.Interval)/1000;
            if (elapsed >= time||_continue == false)
            {
                tm1.Stop();
                _continue = false;
                elapsed = 0;
            }
            lbltime.Text = Convert.ToString(elapsed);
        }
        public static byte[] ConcatArray(byte [] first, byte [] second)
        {
            int two_lenght = first.Length + second.Length;
            byte[] result = new byte[two_lenght];
            for (int i = 0; i < two_lenght;i++)
            {
                if (i < first.Length)
                {
                    result[i] = first[i];
                }
                else
                { 
                    result[i] = second[i-first.Length];
                }
            }
            return result;
        }
        public static Array Redim(Array origArray, Int32 desiredSize)
        {
            Type t = origArray.GetType().GetElementType();
            Array newArray = Array.CreateInstance(t, desiredSize);
            Array.Copy(origArray, 0, newArray, 0, Math.Min(origArray.Length, desiredSize));
            return newArray;
        }
        private void DataReceivedHandlerCPU(object sender, SerialDataReceivedEventArgs e)
        {
            if (_continue == true)
            {
                try
                {
                    //Thread.Sleep(300);//Даем больше времени на ожидание данных//////////////////////////////////////////////////////////////////////////////////1
                    int byteRecieved = _serialPortCPU.BytesToRead;
                    prev_count = byteRecieved;
                    byte[] messByte = new byte[byteRecieved];
                    _serialPortCPU.Read(messByte, 0, byteRecieved);
                    transfer_arr_CPU = ConcatArray(transfer_arr_CPU, messByte);
                    transfer_arr_CPU= ParseForFrame(transfer_arr_CPU);
                    //transfer_arr_CPU = P_R.ALL_OUTBOX;
                    _serialPortSLAVE.Write(newArray.ToArray(), 0, newArray.Count);
                }

                catch (Exception ex)
                {
                    listBoxOut.Invoke(new MethodInvoker(delegate()
                    {
                        listBoxOut.Items.Add(ex.ToString());
                    }
                                                               ));
                }
            }
            else
            {
                _serialPortCPU.Close();
            }
            
        }//Событие появления данных на порту контроллера
        private void DataReceivedHandlerSLAVE(object sender, SerialDataReceivedEventArgs e)
        {
            if (_continue == true)
            {
                try
                {
                    Thread.Sleep(300);//Даем больше времени на ожидание данных
                    int byteRecieved = _serialPortSLAVE.BytesToRead;
                    prev_count_SLAVE = byteRecieved;
                    byte[] messByte = new byte[byteRecieved];
                    _serialPortSLAVE.Read(messByte, 0, byteRecieved);
                    transfer_arr_SLAVE = ConcatArray(transfer_arr_SLAVE, messByte);
                    _serialPortCPU.Write(transfer_arr_SLAVE,0, transfer_arr_SLAVE.Length);
                    
                    //transfer_arr_SLAVE = ParseForFrame(transfer_arr_SLAVE);
                }

                catch (Exception ex)
                {
                    listBoxOut.Invoke(new MethodInvoker(delegate()
                    {
                        listBoxOut.Items.Add(ex.ToString());
                    }
                                                               ));
                }
            }
            else
            {
                _serialPortSLAVE.Close();
            }

        }//Событие появления данных на порту, подключенному к полю

        bool IS_OPEN = false;
        string name = "TEST NAME";
        byte[] message = { 0x68, 0x07, 0x07, 0x68, 0xFF, 0x80, 0x46, 0x3A, 0x3E, 0x02, 0x00, 0x3F, 0x16 };
        private void buttonWR_Click(object sender, EventArgs e)
        {
            _serialPortSLAVE.Write(message, 0,13);
            try
            {
                //Thread.Sleep(300);//Даем больше времени на ожидание данных
                int byteRecieved = _serialPortCPU.BytesToRead;
                prev_count = byteRecieved;
                byte[] messByte = new byte[byteRecieved];
                _serialPortSLAVE.Read(messByte, 0, byteRecieved);
                MessageBox.Show(messByte.ToString());
             
            }

            catch (Exception ex)
            {
                listBoxOut.Invoke(new MethodInvoker(delegate ()
                {
                    listBoxOut.Items.Add(ex.ToString());
                }
                                                           ));
            }
            //readThread.Join();
            //_serialPort.Close();
        }
        unsafe void addFramesFromTestData()
        {
            byte[] test = { 0x68, 0x07, 0x07, 0x68, 0xFF, 0x80, 0x46, 0x3A, 0x3E, 0x02, 0x00, 0x3F, 0x16 };
            //byte[] test33 = { 0x68, 0x07, 0x07, 0x68, 0xFF, 0x80, 0x46, 0x3A, 0x3E, 0x02, 0x00, 0x3F, 0x16 };
            //byte[] test1 = new byte [0];
            byte[] test2 = { 0xDC, 0x01, 0x02 };
            byte[] test3 = { 0x10, 0x00, 0x00, 0x49, 0x49, 0x16 };
            byte[] test4 = { 0xA2, 0xFF, 0x80, 0x46, 0x3A, 0x3E, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x16 };

            byte[] incorrect_msg = { 0x12, 0x21 };
            byte[] incorrect_SD3 = { 0xA2, 0xFF, 0x80, 0x2A, 0x3B, 0x3E, 0x02, 0x00, 0x00, 0x00, 0x00, 0x11, 0x12, 0x16 };

            //byte[] res = ConcatArray(test1, test4);

           // transfer_arr = ParseForFrame(messByte);


            ////fixed (byte* Test = &test[0])
            addFrameToContainer(frameVec, test, test.Count());
            //addFrameToContainer(frameVec, test1, test1.Count());
            //addFrameToContainer(frameVec, test2, test2.Count());
            //addFrameToContainer(frameVec, test3, test3.Count());
            //addFrameToContainer(frameVec, test4, test4.Count());
            //addFrameToContainer(frameVec, incorrect_msg, incorrect_msg.Count());
            //addFrameToContainer(frameVec, incorrect_SD3, incorrect_SD3.Count());
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string path = "";
            openFileDialog1.ShowDialog();
            path = openFileDialog1.FileName;
            FileStream fs = File.OpenRead(path);
            try
            {
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                ParseForFrame(bytes);
            }
            finally
            {
                fs.Close();
            }
        }
        int HexTextPosition = 0;

        //public struct PARSE_RETURN
        //{
        //    public byte[] ALL_OUTBOX;
        //    public byte[] SHORT_OUTBOX;
        //}


        string to_input = "";
        bool RESRV_FACT = false;
        
        List<byte> RemoveElem= new List<byte>();
        List<int> RemoveIndexs = new List<int>();
        List<byte> newArray = new List<byte>();
        
        public byte[] ParseForFrame(byte[] INbox)
        {
            //newArray.Clear();
            int counter = 0;
            //int offset = 0;
            int OFFSET = 0;
            //byte[] NewInbox;
            //PARSE_RETURN P_R = new PARSE_RETURN();
            byte[] OUTBOX = INbox;
            int UNIDENT_FLAG = 0;
            int FRAME_LENGHT = 0;
            byte[] FindFrame = null;
            string UNDEFINED_ERRORS = "";
            string FRAME_ERRORS = "";
            string for_print = "";
            int interval = 0;
            if (INbox != null)
            {
                newArray = INbox.ToList<byte>();
                counter = INbox.Length;
                foreach (byte BYT in INbox)
                {
                    for_print += BYT.ToString("X2") + " ";
                    if (interval == 16)
                    {
                        listViewHexFile.Invoke(new MethodInvoker(delegate()
                        {
                            listViewHexFile.Items.Add(for_print);
                        }
                                                                       ));
                        interval = 0;
                        for_print = "";
                    }
                    interval++;
                }
                listViewHexFile.Invoke(new MethodInvoker(delegate()
                {
                    listViewHexFile.Items.Add("_________________________________________");
                }
                                                                   ));
                int count = INbox.Length;
                char[] temp_ch = new char[count];
                int end;
                int i = 0;
                while (i < INbox.Length)
                {
                    if (checkBox1.Checked == true)
                    {
                        listBoxOut.Invoke(new MethodInvoker(delegate()
                        {
                            listBoxOut.SelectedIndex = listBoxOut.Items.Count - 1;
                        }
                                                                                              ));
                    }
                    
                    byte BYT = INbox[i];

                    //////////////FRAME_TYPE_SD1
                    if (BYT == (byte)FRAME_TYPE.FRAME_TYPE_SD1)
                    {
                        FRAME_LENGHT = 6;
                        end = i + 5;
                        if (end < INbox.Length)
                        {
                            if (INbox[end] == 22)
                            {
                                if (UNDEFINED_ERRORS != "")
                                {
                                    listBoxErr.Invoke(new MethodInvoker(delegate()
                                    {
                                        UNIDENT_ERR++;
                                        listBoxErr.Items.Add(UNDEFINED_ERRORS + " [UNDEFINIT ERROR]");

                                    }                                                     ));
                                    ColorOut(UNDEFINED_ERRORS, "UN", null);

                                }
                                UNDEFINED_ERRORS = "";
                                FindFrame = new byte[FRAME_LENGHT];
                                int k = 0;
                                for (int j = i; j <= end; j++)
                                {
                                    FindFrame[k] = INbox[j];
                                    k++;
                                }
                                PB_Base PB_ELEM = new PB_SD1(ref FindFrame, FindFrame.Length);
                                PB_ELEM.decode();
                                FRAME_ERRORS = PB_ELEM.display() + "[" + displayErrors(PB_ELEM.getRetCode()) + "]";
                                to_input = BitConverter.ToString(FindFrame).Replace("-"," ");
                                ColorOut(to_input, PB_ELEM.GetDirectType(), PB_ELEM); 

                                listBoxOut.Invoke(new MethodInvoker(delegate()
                                {
                                    listBoxOut.Items.Add(FRAME_ERRORS);
                                }
                                                                               ));
                                if (displayErrors(PB_ELEM.getRetCode()) != "OK (No Errors); " && PB_ELEM.GetDirectType() == "->")
                                {
                                    listBoxErr.Invoke(new MethodInvoker(delegate()
                                    {
                                        listBoxErr.Items.Add(FRAME_ERRORS);
                                    }
                                                                   ));
                                    ASK_010_ERR++;
                                    textBox_0x10_ASK.Invoke(new MethodInvoker(delegate()
                                    {
                                        textBox_0x10_ASK.Text = ASK_010_ERR.ToString();
                                    }
                                                                               ));
                                }
                                if (displayErrors(PB_ELEM.getRetCode()) != "OK (No Errors); " && PB_ELEM.GetDirectType() == "<-")
                                {
                                    listBoxErr.Invoke(new MethodInvoker(delegate()
                                    {
                                        listBoxErr.Items.Add(FRAME_ERRORS);
                                    }
                                                                   ));
                                    ANSWER_010_ERR++;
                                    textBoxAnw010.Invoke(new MethodInvoker(delegate()
                                    {
                                        textBoxAnw010.Text = ANSWER_010_ERR.ToString();
                                    }
                                                                               ));
                                }
                                i = end;
                                i++;
                                continue;
                            }
                        }
                        else
                        {///////////////////////////////////////////////////////////////////////////////////////////////////////////
                            
                            byte[] ret_arr = new byte[INbox.Length - i];
                            int d = 0;
                            for (int l = i; l < INbox.Length; l++)
                            {
                                ret_arr[d] = INbox[l];
                                d++;
                            }
                            RESRV_FACT = false;
                            return ret_arr;
                        }
                    }
                    
                    //////////////FRAME_TYPE_SD2
                    if (BYT == (byte)FRAME_TYPE.FRAME_TYPE_SD2 && INbox.Length > i + 1)
                    {
                        FRAME_LENGHT = Convert.ToInt32(INbox[i + 1]) + 6;
                        end = i + FRAME_LENGHT - 1;
                        if (end < INbox.Length)
                        {
                            if (BYT == INbox[i + 3])
                            {
                                if (UNDEFINED_ERRORS != "")
                                {
                                    listBoxErr.Invoke(new MethodInvoker(delegate()
                                    {
                                        UNIDENT_ERR++;
                                        listBoxErr.Items.Add(UNDEFINED_ERRORS + " [UNDEFINIT ERROR] I=" +i.ToString());
                                    }
                                                                                         ));
                                    ColorOut(UNDEFINED_ERRORS, "UN", null);
                                }
                                UNDEFINED_ERRORS = "";
                                FindFrame = new byte[FRAME_LENGHT];
                                int k = 0;
                                for (int j = i; j <= end; j++)
                                {
                                    FindFrame[k] = INbox[j];
                                    k++;
                                }
                                PB_Base PB_ELEM = new PB_SD2(ref FindFrame, FindFrame.Length);
                                PB_ELEM.decode();
                              
                                FRAME_ERRORS = PB_ELEM.display() + "[" + displayErrors(PB_ELEM.getRetCode()) + "]";


                                if ((PB_ELEM.GetFCtype() == "SDN (Send Data with No Acknowledge high) " && FindFrame[FindFrame.Length-4]  == 0x02) || RESRV_FACT == true && PB_ELEM.GetDirectType() == "->" )//REMOVE DATA UNIT FROM ARRAY (8 LENGHT)
                                {
                                    try
                                    {
                                        if (tested != true)
                                        {
                                            RESRV_FACT = true;
                                            FRAME_ERRORS += "   <==================!!!SDN_CLEAR_STATUS_DETECTECD!!!================> ";
                                            tabControl1.Invoke(new MethodInvoker(delegate ()
                                            {
                                                this.tabControl1.SelectedTab = tabControl1.TabPages[1];

                                            }
                                                                                        ));
                                            RemoveElem.Clear();
                                            RemoveIndexs.Clear();

                                            
                                            for (int h = i + 7; h < end - 1; h++)
                                                    {
                                                        RemoveElem.Add(INbox[h]);
                                                        RemoveIndexs.Add(h);
                                                    }

                                                    foreach (int INDEX in RemoveIndexs)
                                                    {
                                                        newArray.RemoveAt(INDEX - OFFSET);
                                                        OFFSET++;
                                                    }
                                            
                                            newArray[RemoveIndexs[0] - OFFSET - 1] = 0x03;
                                            newArray[RemoveIndexs[0] - OFFSET - 2] = 0x03;
                                            newArray[RemoveIndexs[0] - OFFSET + 4] = PB_ELEM.fcs_withoutData;



                                            //MessageBox.Show(newArray[RemoveIndexs[0] - offset - 3].ToString()+ " "+ newArray[RemoveIndexs[0] - offset - 2].ToString() + " " + newArray[RemoveIndexs[0] - offset - 1].ToString());


                                            String CUT_DATA = "";
                                            foreach (int elem in RemoveElem)
                                            {
                                                CUT_DATA += elem.ToString("X2") + " ";
                                            }

                                            listBoxOut.Invoke(new MethodInvoker(delegate ()
                                            {
                                                listBoxOut.Items.Add(CUT_DATA);
                                            }
                                                                                       ));
                                        }
                                        

                                       
                                    }
                                    catch { MessageBox.Show("FUCK"); }

                                }
                                //FindFrame = 
                                to_input = BitConverter.ToString(FindFrame).Replace("-", " ");////////////////////////!!!!!!!!!!!!!!!!!!!!
                                ColorOut(to_input, PB_ELEM.GetDirectType(), PB_ELEM);

                                listBoxOut.Invoke(new MethodInvoker(delegate()
                                {
                                    listBoxOut.Items.Add(FRAME_ERRORS);
                                    //listBoxOut.Items.Add("i= " + i.ToString() + " " + newArray[i].ToString() + newArray[i]);
                                }
                                                                               ));
                                if (displayErrors(PB_ELEM.getRetCode()) != "OK (No Errors); " && PB_ELEM.GetDirectType() == "->")
                                {
                                    listBoxErr.Invoke(new MethodInvoker(delegate()
                                    {
                                        listBoxErr.Items.Add(FRAME_ERRORS);
                                    }
                                                                   ));
                                    ASK_068_ERR++;
                                    textBox_0x68_ASK.Invoke(new MethodInvoker(delegate()
                                    {
                                        textBox_0x68_ASK.Text = ASK_068_ERR.ToString();
                                    }
                                                                               ));
                                }
                                if (displayErrors(PB_ELEM.getRetCode()) != "OK (No Errors); " && PB_ELEM.GetDirectType() == "<-")
                                {
                                    listBoxErr.Invoke(new MethodInvoker(delegate()
                                    {
                                        listBoxErr.Items.Add(FRAME_ERRORS);
                                    }
                                                                   ));
                                    ANSWER_068_ERR++;
                                    textBox_0x68_ANSW.Invoke(new MethodInvoker(delegate()
                                    {
                                        textBox_0x68_ANSW.Text = ANSWER_068_ERR.ToString();
                                    }
                                                                               ));
                                }
                                i = end;
                                i++;
                                continue;
                            }
                        }

                        else
                        {
                            byte[] ret_arr = new byte[INbox.Length - i];
                            int d = 0;
                            for (int l = i; l < INbox.Length; l++)
                            {
                                ret_arr[d] = INbox[l];
                                d++;
                            }
                            RESRV_FACT = false;
                            return ret_arr;
                        }
                    }

                    /////////////////////////FRAME_TYPE_SD3
                    if (BYT == (byte)FRAME_TYPE.FRAME_TYPE_SD3)
                    {
                        FRAME_LENGHT = Convert.ToInt32(INbox[i + 1]) + 7;
                        end = i + FRAME_LENGHT - 1;
                        if (end < INbox.Length)
                        {
                            if (INbox[i + 7] == 22)
                            {
                                if (UNDEFINED_ERRORS != "")
                                {
                                    listBoxOut.Invoke(new MethodInvoker(delegate()
                                    {
                                        UNIDENT_ERR++;
                                        listBoxErr.Items.Add(UNDEFINED_ERRORS + " [UNDEFINIT ERROR]");
                                    }
                                                                                          ));
                                    ColorOut(UNDEFINED_ERRORS,  "UN", null);
                                }
                                UNDEFINED_ERRORS = "";
                                FindFrame = new byte[FRAME_LENGHT];
                                int k = 0;
                                for (int j = i; j <= end; j++)
                                {
                                    FindFrame[k] = INbox[j];
                                    k++;
                                }
                                PB_Base PB_ELEM = new PB_SD3(ref FindFrame, FindFrame.Length);
                                PB_ELEM.decode();
                                FRAME_ERRORS = PB_ELEM.display() + "[" + displayErrors(PB_ELEM.getRetCode()) + "]";
                                to_input = BitConverter.ToString(FindFrame).Replace("-", " ");
                                ColorOut(to_input, PB_ELEM.GetDirectType(), PB_ELEM); 

                                listBoxErr.Invoke(new MethodInvoker(delegate()
                                {
                                    listBoxErr.Items.Add(FRAME_ERRORS);
                                }
                                                                ));

                                listBoxOut.Invoke(new MethodInvoker(delegate()
                                {
                                    listBoxOut.Items.Add(FRAME_ERRORS);
                                }
                                                                               ));
                                i = end;
                                i++;
                                continue;
                            }
                        }
                        else
                        {
                            byte[] ret_arr = new byte[INbox.Length - i];
                            int d = 0;
                            for (int l = i; l < INbox.Length; l++)
                            {
                                ret_arr[d] = INbox[l];
                                d++;
                            }
                            RESRV_FACT = false;
                            return ret_arr;
                        }
                    }
                    /////////////////////////FRAME_TYPE_SD4
                    if (BYT == (byte)FRAME_TYPE.FRAME_TYPE_SD4 && i + 1 < INbox.Length)
                    {
                        FRAME_LENGHT = 3;
                        end = i + FRAME_LENGHT - 1;
                        if (end < INbox.Length)
                        {
                            if (INbox[i+1] == 0x01 && INbox[i+2] == 0x01)/////INbox[i - 1] == 0x16 || INbox[i - 1] == 0xE5 || 
                            {
                                if (UNDEFINED_ERRORS != "")
                                {
                                    listBoxOut.Invoke(new MethodInvoker(delegate()
                                    {
                                        UNIDENT_ERR++;
                                        listBoxErr.Items.Add(UNDEFINED_ERRORS + " [UNDEFINIT ERROR]");
                                    }                                                   ));
                                    ColorOut(UNDEFINED_ERRORS, "UN", null);
                                    
                                }
                                UNDEFINED_ERRORS = "";
                                FindFrame = new byte[FRAME_LENGHT];
                                int k = 0;
                                for (int j = i; j <= end; j++)
                                {
                                    FindFrame[k] = INbox[j];
                                    k++;
                                }
                                PB_Base PB_ELEM = new PB_SD4(ref FindFrame, FindFrame.Length);
                                PB_ELEM.decode();
                                FRAME_ERRORS = PB_ELEM.display() + "[" + displayErrors(PB_ELEM.getRetCode()) + "]";
                                to_input = BitConverter.ToString(FindFrame).Replace("-", " ");
                                ColorOut(to_input, "DC", null); 

                                listBoxOut.Invoke(new MethodInvoker(delegate()
                                {
                                    listBoxOut.Items.Add(FRAME_ERRORS);
                                }
                                                                               ));
                                i = end;
                                i++;
                                continue;
                            }
                        }

                        else
                        {
                            byte[] ret_arr = new byte[INbox.Length - i];
                            int d = 0;
                            for (int l = i; l < INbox.Length; l++)
                            {
                                ret_arr[d] = INbox[l];
                                d++;
                            }
                            return ret_arr;
                        }

                    }
                    /////////////////////////FRAME_TYPE_SC
                    if (BYT == (byte)FRAME_TYPE.FRAME_TYPE_SC && i - 4 > 0)
                    {
                        FRAME_LENGHT = 1;
                        end = i + FRAME_LENGHT - 1;
                        if (end < INbox.Length)
                        {
                            if (INbox[i + 1] == 0x16 || INbox[i - 3] == 0xDC)
                            {
                                if (UNDEFINED_ERRORS != "")
                                {
                                    listBoxOut.Invoke(new MethodInvoker(delegate()
                                    {
                                        UNIDENT_ERR++;
                                        listBoxErr.Items.Add(UNDEFINED_ERRORS + " [UNDEFINIT ERROR]");
                                    }
                                                                                          ));
                                    ColorOut(UNDEFINED_ERRORS, "UN", null);
                                }
                                UNDEFINED_ERRORS = "";
                                FindFrame = new byte[FRAME_LENGHT];
                                int k = 0;
                                for (int j = i; j <= end; j++)
                                {
                                    FindFrame[k] = INbox[j];
                                    k++;
                                }
                                PB_Base PB_ELEM = new PB_SC(ref FindFrame, FindFrame.Length);
                                PB_ELEM.decode();
                                FRAME_ERRORS = PB_ELEM.display() + "[" + displayErrors(PB_ELEM.getRetCode()) + "]";

                                to_input = BitConverter.ToString(FindFrame).Replace("-", " ");
                                ColorOut(to_input, PB_ELEM.GetDirectType(), PB_ELEM); 
                                
                                listBoxErr.Invoke(new MethodInvoker(delegate()
                                {
                                    listBoxErr.Items.Add(FRAME_ERRORS);
                                }
                                                               ));
                                listBoxOut.Invoke(new MethodInvoker(delegate()
                                {
                                    listBoxOut.Items.Add(FRAME_ERRORS);
                                }
                                                                               ));
                                i = end;
                                i++;
                                continue;
                            }
                        }

                        else
                        {
                            byte[] ret_arr = new byte[INbox.Length - i];
                            int d = 0;
                            for (int l = i; l < INbox.Length; l++)
                            {
                                ret_arr[d] = INbox[l];
                                d++;
                            }
                            return ret_arr;
                        }
                    }
                    if (i == INbox.Length - 1)
                    {
                        byte[] ret_arr = new byte[INbox.Length - i];
                        int d = 0;
                        for (int l = i; l < INbox.Length; l++)
                        {
                            ret_arr[d] = INbox[l];
                            d++;
                        }
                        RESRV_FACT = false;
                        return ret_arr;
                    }
                    UNDEFINED_ERRORS += " " + Convert.ToByte(BYT).ToString("x2");
                    UNIDENT_FLAG++;
                    if (UNIDENT_FLAG == 16)
                    {
                        listBoxErr.Invoke(new MethodInvoker(delegate()
                        {
                            UNIDENT_ERR++;
                            listBoxErr.Items.Add(UNDEFINED_ERRORS + " [UNDEFINIT ERROR]");
                            ColorOut(UNDEFINED_ERRORS, "UN", null);
                        }
                                                              ));
                        UNIDENT_FLAG = 0;
                        UNDEFINED_ERRORS = "";
                    }
                    textBoxUNIdent.Invoke(new MethodInvoker(delegate()
                    {
                        textBoxUNIdent.Text = UNIDENT_ERR.ToString();
                    }
                                                               ));

                    if (ASK_068_ERR != 0 || ANSWER_068_ERR != 0 || ASK_010_ERR != 0 || ANSWER_010_ERR != 0 || UNIDENT_ERR != 0)
                    {
                        textBoxUNIdent.Invoke(new MethodInvoker(delegate()
                    {
                        lblStatus.Text = "THERE ARE SOME ERRORS!!!";
                        lblStatus.ForeColor = Color.Red;
                    }
                                                               ));
                    }
                    i++;

                } //END LOOP
                byte[] empty2 = new byte[0];
                return empty2;

            }



            else
            { MessageBox.Show(""); }
            byte[]empty = new byte[0];
            return empty;
        }
        private int find_str(ListViewItem Itm, string frg, int lenght)
        {
            string Line = Itm.Text;
            for (int i = 0; i < Line.Length - lenght; i++)
            {
                string str_frag = Line.Substring(i, lenght);
                if (str_frag == frg)
                {
                    return Itm.Index;
                }


            }
            return 0;
        }
        private int find_str_listBox(ListViewItem Itm, string frg, int lenght)
        {
            string Line = Itm.Text;
            for (int i = 0; i < Line.Length - lenght; i++)
            {
                string str_frag = Line.Substring(i, lenght);
                if (str_frag == frg)
                {
                    return Itm.Index;
                }
            }
            return 0;
        }
        List<Int32> retList = new List<int>();
        private void cmbSearchChanged(object sender, EventArgs e)
        {
            retList.Clear();
            ComboBox textBox = (ComboBox)sender;
            try
            {
                        
                        foreach (ListViewItem item in this.listViewHewColor.Items)
                        {
                            if (find_str(item, textBox.Text, textBox.Text.Length) != 0)
                            {
                                retList.Add(find_str(item, textBox.Text, textBox.Text.Length));
                            }
                        }
            
                //listViewHewColor.Items[retList[0]].Selected = true;
                //listViewHewColor.Select();
                //listViewHewColor.Items[retList[0]].EnsureVisible();
                //textBox.Focus();
            }
            catch {  }
            if (retList.Count == 0)
            {MessageBox.Show("'" + textBox.Text + "'" + " NOT FOUND");}
            lblFound.Text = retList.Count.ToString();
        }
        private void cmbSearchChangedHex(object sender, EventArgs e)
        {
            retList.Clear();
            ComboBox textBox = (ComboBox)sender;
            try
            {

                foreach (ListViewItem item in this.listViewHexFile.Items)
                {
                    if (find_str(item, textBox.Text, textBox.Text.Length) != 0)
                    {
                        retList.Add(find_str(item, textBox.Text, textBox.Text.Length));
                    }
                }

                //listViewHewColor.Items[retList[0]].Selected = true;
                //listViewHewColor.Select();
                //listViewHewColor.Items[retList[0]].EnsureVisible();
                //textBox.Focus();
            }
            catch { }
            if (retList.Count == 0)
            { MessageBox.Show("'" + textBox.Text + "'" + " NOT FOUND"); }
            lblFound.Text = retList.Count.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBoxErr.Items.Clear();
            listBoxOut.Items.Clear();
            listViewHexFile.Items.Clear();
            listViewHewColor.Clear();
            HexTextPosition = 0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBoxErr.Items.Clear();
            listBoxOut.Items.Clear();
            //listBoxHexFile.Items.Clear();
            listViewHewColor.Clear();
            HexTextPosition = 0;
            lblStatus.ForeColor = Color.Black;
            lblStatus.Text = "CLEARED! READY TO START";
        }
        private void profibusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "";
            openFileDialog1.ShowDialog();
            path = openFileDialog1.FileName;
            try
            {
                FileStream fs = File.OpenRead(path);
           
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                ParseForFrame(bytes);
                fs.Close();

            }
            catch { MessageBox.Show("PLEASE SET CORRECT PARH!"); }
         
        }
        #region
        private static readonly byte[] Empty = new byte[0];
        public static byte[] ConvertToByteArray(string value)
        {
            byte[] bytes = null;
            if (String.IsNullOrEmpty(value))
                bytes = Empty;
            else
            {
                int string_length = value.Length;
                int character_index = (value.StartsWith("0x", StringComparison.Ordinal)) ? 2 : 0; // Does the string define leading HEX indicator '0x'. Adjust starting index accordingly.               
                int number_of_characters = string_length - character_index;

                bool add_leading_zero = false;
                if (0 != (number_of_characters % 2))
                {
                    add_leading_zero = true;

                    number_of_characters += 1;  // Leading '0' has been striped from the string presentation.
                }

                bytes = new byte[number_of_characters / 2]; // Initialize our byte array to hold the converted string.

                int write_index = 0;
                if (add_leading_zero)
                {
                    bytes[write_index++] = FromCharacterToByte(value[character_index], character_index);
                    character_index += 1;
                }

                for (int read_index = character_index; read_index < value.Length; read_index += 2)
                {
                    byte upper = FromCharacterToByte(value[read_index], read_index, 4);
                    byte lower = FromCharacterToByte(value[read_index + 1], read_index + 1);

                    bytes[write_index++] = (byte)(upper | lower);
                }
            }

            return bytes;
        }
        private static byte FromCharacterToByte(char character, int index, int shift = 0)
        {
            byte value = (byte)character;
            if (((0x40 < value) && (0x47 > value)) || ((0x60 < value) && (0x67 > value)))
            {
                if (0x40 == (0x40 & value))
                {
                    
                        if (0x20 == (0x20 & value))
                            value = (byte)(((value + 0xA) - 0x61) << shift);
                        else
                            value = (byte)(((value + 0xA) - 0x41) << shift);
                    
                }

            }
            else if ((0x29 < value) && (0x40 > value))
                value = (byte)((value - 0x30) << shift);
            else
               throw new InvalidOperationException(String.Format("Character '{0}' at index '{1}' is not valid alphanumeric character.", character, index));

            return value;
        }
        #endregion
        private void profibusToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string to_array = "";
            saveFileDialog1.ShowDialog();
            string path = saveFileDialog1.FileName;
            //int i = 0;
            
            foreach(var item in listViewHewColor.Items.Cast<ListViewItem>())
            {
                to_array += item.Text.Replace(" ", string.Empty);
               
            }
            byte[] to_save = ConvertToByteArray(to_array);
            File.WriteAllBytes(path, to_save);
        }
        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        int ELEMIn = 0;
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
               
                listViewHewColor.Items[retList[ELEMIn]].Selected = true;
                listViewHewColor.Select();
                listViewHewColor.Items[retList[ELEMIn]].EnsureVisible();
                ELEMIn--;
            }
            catch { ELEMIn = 0; }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                listViewHewColor.Items[retList[ELEMIn]].Selected = true;
                listViewHewColor.Select();
                listViewHewColor.Items[retList[ELEMIn]].EnsureVisible();
                ELEMIn++;
                
            }
            catch { ELEMIn = 0; }
        }
        private void listViewHewColor_RightMouseClicked(object sender, MouseEventArgs e)
        {
            
                if (e.Button == MouseButtons.Right)
                {
                    if (listViewHewColor.FocusedItem.Bounds.Contains(e.Location) == true)
                    {
                        contextMenuStrip1.Show(Cursor.Position);
                    }
                } 

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {

                listViewHewColor.Items[retList[ELEMIn]].Selected = true;
                listViewHewColor.Select();
                listViewHewColor.Items[retList[ELEMIn]].EnsureVisible();
                ELEMIn++;

            }
            catch { ELEMIn = 0; }
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {

                listViewHewColor.Items[retList[ELEMIn]].Selected = true;
                listViewHewColor.Select();
                listViewHewColor.Items[retList[ELEMIn]].EnsureVisible();
                ELEMIn--;
            }
            catch { ELEMIn = 0; }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                listViewHexFile.Items[retList[ELEMIn]].Selected = true;
                listViewHexFile.Select();
                listViewHexFile.Items[retList[ELEMIn]].EnsureVisible();
                ELEMIn++;

            }
            catch { ELEMIn = 0; }
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {

                listViewHexFile.Items[retList[ELEMIn]].Selected = true;
                listViewHexFile.Select();
                listViewHexFile.Items[retList[ELEMIn]].EnsureVisible();
                ELEMIn--;
            }
            catch { ELEMIn = 0; }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        byte[] data = new byte[256];
        public static void Read()
        {
            while (_continue)
            {
                try
                {
                    string message = _serialPortSLAVE.ReadLine();
                    MessageBox.Show(message);
                }
                catch (TimeoutException) { }
            }
        }
        bool tested = false;
        private void button5_Click(object sender, EventArgs e)
        {
            RESRV_FACT = false;
            //int OFFSET = 0;
            tested = true;
            
            //MessageBox.Show(newArray[1924].ToString() + " " + newArray[1925].ToString() + " "+newArray[1926].ToString() + " "+newArray[1927].ToString() + " "+ newArray[1928].ToString() + " ");
            ParseForFrame(newArray.ToArray<byte>());
        }
    }
}
