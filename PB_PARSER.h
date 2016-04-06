
#include "stdafx.h"
#include <iostream>
#include <vector>
#include <fstream> 
#include <string>

using namespace std;

template <typename T> unsigned short toUnsignedShort(T data) 
{ 
	return static_cast<unsigned short>(data);
}

template <typename T> unsigned short toUnsignedChar(T data)
{
	return static_cast<unsigned char>(data);
}

unsigned char checksum(unsigned char *ptr, size_t sz) {
	unsigned char chk = 0;
	while (sz-- != 0)
		chk += *ptr++;
	return chk;
}

bool frameType(unsigned char fc)
{
	return ((0x40)&(fc)) ? true : false;
}

bool fcb(unsigned char fc)
{
	return ((0x20)&(fc)) ? true : false;
}

bool fcv(unsigned char fc)
{
	return ((0x10)&(fc)) ? true : false;
}

void stationType(ostream& os, unsigned char fc)
{
	switch (fc&(0x30))
	{
	case 0x10:
		os << "(active station not ready) ";
		break;

	case 0x20:
		os << "(active station for token ring) ";
		break;

	case 0x18:
		os << "(active station is  token ring) ";
		break;

	default:
		os << "(passive station) ";
		break;
	}

	return;
}

void displayFrameType(ostream& os, unsigned char fc)
{
	bool ft,fcb_,fcv_;
	ft = frameType(fc);
	fcb_ = fcb(fc);
	fcv_ = fcv(fc);

	ft ?( os << "Request ") : ( os << "Response ");

	// FCB=Frame Control Bit (inverted inition bit) and FCV=Frame Count Bit valid (1 = other FCB is valid)
	if (ft) os << "FCB=" << fcb_ << " FCV=" << fcv_;
	else os << "Station type=", stationType(os, fc);

		
	os << " ";
	return;
}

void displayArrow(ostream& os, bool ft)
{
	ft ? (os << "->") : (os << "<-");
	return;
}

bool areSapsPresented(unsigned char *dsap)
{
	unsigned char *ssap = dsap + 1;
	return (((*ssap) & 0x3E)) ? true : false;
}

void displaySaps(ostream& os, unsigned char *dsap,bool ft)
{
	unsigned char *ssap = dsap+1;
	if (!(areSapsPresented(dsap))) { os << "No SAPs (data tranfer)"; return; }

	os << "SAPs (dec) " << toUnsignedShort(*ssap);
	displayArrow(os, ft);
	os << toUnsignedShort(*dsap) << " ";
	return;
}

void displayFunction(ostream& os, unsigned char fc, bool ft)
{
	if (ft)
	{
		switch (fc & 0x0F)
		{

		case 0x03:
			os << "SDA (Send Data with Acknowledge low) ";
			break;

		case 0x04:
			os << "SDN (Send Data with No Acknowledge low) ";
			break;

		case 0x05:
			os << "SDA (Send Data with Acknowledge high) ";
			break;

		case 0x06:
			os << "SDN (Send Data with No Acknowledge high) ";
			break;

		case 0x09:
			os << "(Request FDL status with reply) ";
			break;

		case 0x0C:
			os << "SRD (Send and Request Data low) ";
			break;

		case 0x0D:
			os << "SRD (Send and Request Data high) ";
			break;

		case 0x0E:
			os << "(Request Ident with Reply) ";
			break;

		case 0x0F:
			os << "(Request LSAP-Status with Reply) ";
			break;

		default:
			os << "Reserved ";
			break;
		}

		
		return;
	}
		
	else
	{
		switch (fc & 0x0F)
		{

		case 0x00:
			os << "OK (ACK positive) ";
			break;

		case 0x01:
			os << "UE (ACK negative FDL, FMA1/2-User Error) ";
			break;

		case 0x02:
			os << "RR (ACK negative, no resource for send data) ";
			break;

		case 0x03:
			os << "RS (ACK negative, no service activated) ";
			break;

		case 0x08:
			os << "DL (Response FDL, FMA1/2-Data low send data OK) ";
			break;

		case 0x09:
			os << "NR (ACK negative, No Response FDL, FMA1/2-Data, send data OK) ";
			break;

		case 0x0A:
			os << "DH (Response FDL-data high, send data OK) ";
			break;

		case 0x0C:
			os << "RDL (Response FDL-data low, no resource for send data) ";
			break;

		case 0x0D:
			os << "RDH (Response FDL-data high, no resource for send data) ";
			break;

		default:
			os << "Reserved ";
			break;
		}
	}
	return;
}
enum
{
	NO_ERR = 0,			// OK. No Errors in frame
	WRONG_SD = 0x01,	// Incorrect Frame start byte
	WRONG_FCS = 0x02,	// Incorrect CRC
	WRONG_ED = 0x04,	// Incorrect end byte (almost always must be 0x16)
	LE_ERR = 0x08,		// LE!=LEr (different 2nd and 3rd bytes for SD= 0x68)
	SD2_ERR = 0x10		// different SD2 (byte 1 and 4)
	// Add UNDEFINED ERROR type in C# RELEASE
};

enum
{
	FRAME_TYPE_SD1 = 0x10,
	FRAME_TYPE_SD2 = 0x68,
	FRAME_TYPE_SD3 = 0xA2,
	FRAME_TYPE_SD4 = 0xDC,
	FRAME_TYPE_SC = 0xE5
};

void displayErrors(ostream& os, unsigned char ec)
{
	if (!ec) os << "OK (No Errors); ";
	else
	{

		if (ec&WRONG_SD) os << "WRONG_SD; ";
		if (ec&WRONG_FCS) os << "WRONG_FCS; ";
		if (ec&WRONG_ED) os << "WRONG_ED; ";
		if (ec&LE_ERR) os << "LE_ERR; ";
		if (ec&SD2_ERR) os << "SD2_ERR; ";
	}

	return;
}

class PB_Base{
	public: 
		PB_Base(unsigned char *ptr, size_t sz) :buffer(ptr), len(sz), retCode(NO_ERR) {}
		PB_Base(const PB_Base& other) :buffer(other.buffer), len(other.len), retCode(other.retCode) {}
		virtual ~PB_Base() {}

		virtual unsigned char display(ostream& os) = 0;
		unsigned char getRetCode(void) const  { return retCode; }
		void setRetCode(unsigned char code) { retCode = code; }
		unsigned char *getBuffer(void) const { return buffer; }
		size_t  getLen(void) const { return len; }
		virtual void decode(void) { return; }
				
	private:
		unsigned char *buffer;
		size_t len;
		unsigned char retCode;
};

class PB_Default : public PB_Base{
public:
	PB_Default(unsigned char *p, size_t l) :PB_Base(p, l) {}

	void decode(void)
	{
		setRetCode(WRONG_SD);
		return;
	}

	unsigned char display(ostream& os)
	{
		os << "Incorrect Frame start byte" << endl;
		os << "_______________________________________________________________";
		return getRetCode();
	}

};

class PB_SC: public PB_Base{

public:
	PB_SC(unsigned char *p, size_t l) :PB_Base(p, l) {}
	unsigned char display(ostream& os)
	{ 
		os << "Short acknowledge message" << endl;
		os << "_______________________________________________________________";
		return getRetCode();
	}
};

class PB_SD4 : public PB_Base{

public:
	PB_SD4(unsigned char *p, size_t l) :PB_Base(p, l) {}

	void decode(void)
	{
		unsigned char *buf = getBuffer();
		da = toUnsignedShort(buf[2]);
		sa = toUnsignedShort(buf[1]);

		return;
	
	}
	unsigned char display(ostream& os)
	{
		os << "Token transfer message:" << endl;
		os << "ADDR (dec)" << dec << da << "->" << sa << endl;
		os << "_______________________________________________________________";
		return getRetCode();
	}

private:
	unsigned short da = 0, sa = 0;
};


class PB_SD2 : public PB_Base {

public:
	PB_SD2(unsigned char *p, size_t l):PB_Base(p,l) {}
	
	
	void decode(void)
	{
		unsigned char *buf = getBuffer();
		size_t len = getLen();
	
		da = toUnsignedShort(buf[4]);
		sa = toUnsignedShort(buf[5]);
		le = toUnsignedShort(buf[1]);
		fc = buf[6];
		fsc = toUnsignedShort(buf[le + 4]);
		ft = frameType(buf[6]);

		if (buf[3] != buf[0]) setRetCode(getRetCode() | SD2_ERR);
		if (buf[1] != buf[2]) setRetCode(getRetCode() | LE_ERR);
		if (buf[len - 1] != 0x16) setRetCode(getRetCode() | WRONG_ED);
		if (fsc != toUnsignedShort(checksum(buf + 4, le))) setRetCode(getRetCode() | WRONG_FCS);

		dataLen = (areSapsPresented(buf + 7)) ? (le - 5) : (le - 3);
		dataBegin = 4 - dataLen + le;

		ed = toUnsignedShort(buf[len - 1]);

		return;
	}

	unsigned char display(ostream& os)
	{
		os << "Data transfer:" << endl;
		unsigned char *buf = getBuffer();
		size_t len = getLen();

		os << "ADDR (dec)" << dec << da;
		displayArrow(os, ft);
		os << sa << " ";
		os << "frame_type=", displayFrameType(os, fc);
		os << " function=", displayFunction(os, fc, ft), os << " ";	

		displaySaps(os, buf + 7, ft);		
		os << "dataLen=" << dataLen << " DATA=";

		os.unsetf(ios::dec);
		os.setf(ios::hex);

		for (unsigned short i = dataBegin; i < dataBegin + dataLen; ++i)
		{
			if (buf[i] < 16) os << "0";
			os << hex << toUnsignedShort(buf[i]) << " ";
		}

		os << "CRC="  << hex << fsc;
		os << " End=" << hex << ed << endl;

		os << "_______________________________________________________________";

 		return getRetCode();
	}

private:
	unsigned short da = 0, sa = 0, le = 0, fsc = 0, dataBegin = 0 , ed = 0;
	unsigned char fc = 0;
	bool ft = false;
	size_t dataLen = 0;
};

class PB_SD1 : public PB_Base {

public:
	PB_SD1(unsigned char *p, size_t l) :PB_Base(p, l) {}

	void decode(void)
	{	
		unsigned char *buf = getBuffer();
		size_t len = getLen();

		da = toUnsignedShort(buf[1]);
		sa = toUnsignedShort(buf[2]);
		fc = buf[3];
		fsc = toUnsignedShort(buf[4]);
		ft = frameType(buf[3]);

		if (buf[len - 1] != 0x16) setRetCode(getRetCode() | WRONG_ED);
		if (fsc != toUnsignedShort(checksum(buf + 1, 3))) setRetCode(getRetCode() | WRONG_FCS);

		ed = toUnsignedShort(buf[5]);

		return;

	}

	unsigned char display(ostream& os)
	{
		os << "Status request or acknowledge message:" << endl;
		unsigned char *buf = getBuffer();
		size_t len = getLen();
		
		os << "ADDR (dec)" << dec << da;
		displayArrow(os, ft);
		os << sa << " ";
		os << "frame_type=", displayFrameType(os, fc);
		os << " function=", displayFunction(os, fc, ft), os << " ";
		os << "CRC="  << hex << fsc;
		os << " End=" << hex << ed << endl;
		os << "_______________________________________________________________";

		return getRetCode();
	}

private:
	unsigned short da = 0, sa = 0, fsc = 0, ed = 0;
	unsigned char fc = 0;
	bool ft = false;

};
class PB_SD3 : public PB_Base {

public:
	PB_SD3(unsigned char *p, size_t l) :PB_Base(p, l) {}

	void decode(void)
	{
		unsigned char *buf = getBuffer();
		size_t len = getLen();

		da = toUnsignedShort(buf[1]);
		sa = toUnsignedShort(buf[2]);
		fc = buf[3];
		fsc = toUnsignedShort(buf[12]);
		ft = frameType(buf[3]);
		dataLen = 8;  // 8 bytes is max - 11 bytes minus 3 bytes: DA,SA,FC; 6 bytes in case of SAPs are presented
		dataBegin = 0;

		if (buf[len - 1] != 0x16) setRetCode(getRetCode() | WRONG_ED);
		if (fsc != toUnsignedShort(checksum(buf + 1, 11))) setRetCode(getRetCode() | WRONG_FCS);

		dataLen = (areSapsPresented(buf + 4)) ? (11 - 5) : (11 - 3);
		dataBegin = 1 - dataLen + 11;
		ed = toUnsignedShort(buf[len - 1]);

		return;
	}

	unsigned char display(ostream& os)
	{
		os << "Data transfer (fixed length = 11 bytes):" << endl;
		unsigned char *buf = getBuffer();
		size_t len = getLen();

		os << "ADDR (dec)" << dec << da;
		displayArrow(os, ft);
		os << sa << " ";
		os << "frame_type=", displayFrameType(os, fc);
		os << " function=", displayFunction(os, fc, ft), os << " ";

		displaySaps(os, buf + 4, ft);
		os << "dataLen=" << dataLen << " DATA=";

		os.unsetf(ios::dec);
		os.setf(ios::hex);

		for (unsigned short i = dataBegin; i < dataBegin + dataLen; ++i)
		{
			if (buf[i] < 16) os << "0";
			os << toUnsignedShort(buf[i]) << " ";
		}

		os << "CRC=" << hex << fsc;
		os << " End=" << hex << ed << endl;

		os << "_______________________________________________________________";

		return getRetCode();
	}

private:
	unsigned short da = 0, sa = 0, le = 0, fsc = 0, dataBegin = 0, ed = 0;
	unsigned char fc = 0;
	bool ft = false;
	size_t dataLen = 0;
};

typedef vector<PB_Base *> myContainer;
myContainer frameVec;

template<typename T>
void addFrameToContainer(T & container, unsigned char * buf, size_t len)
{
	PB_Base *ptr;

	switch (buf[0])
	{
	case FRAME_TYPE_SD2:
		ptr = new PB_SD2(buf, len);
		break;

	case FRAME_TYPE_SC:
		ptr = new PB_SC(buf, len);
		break;

	case FRAME_TYPE_SD4:
		ptr = new PB_SD4(buf, len);
		break;

	case FRAME_TYPE_SD1:
		ptr = new PB_SD1(buf, len);
		break;

	case FRAME_TYPE_SD3:
		ptr = new PB_SD3(buf, len);
		break;

	default:
		ptr = new PB_Default(buf, len);
		break;
	}

	container.push_back(ptr);

	return;
}

bool addFramesFromFile(const char * fileName)
{
	ifstream inputFile;
	unsigned char * buf = 0;

	inputFile.open(fileName, std::ofstream::in);
	if (!inputFile.is_open()) { cout << "Unable read data from file:" << fileName << " test will be proceed" << endl; return true; }

	for (string line; getline(inputFile, line);)
	{
		short i = 0, lineLen = 0;

		while ((i = (line.find(' '))) != (std::string::npos)) line.erase(i, 1);
		lineLen = line.length();

		if (lineLen & 1) { cout << line << "Line length is odd, zero ending added" << endl; line += "0"; lineLen = line.length(); }

		buf = new unsigned char[sizeof(char)*(lineLen >> 1)];

		for (short j = 0, bufIndex = 0; j < lineLen; ++j, ++bufIndex)
		{
			string subLine = line.substr(j, 2);
			int num = stoi(subLine, 0, 16);
			buf[bufIndex] = toUnsignedChar(num);
			++j;
		}
		addFrameToContainer<myContainer>(frameVec, buf, lineLen >> 1);

	}

	inputFile.close();

	return false;
}

void addFramesFromTestData(void)
{
	static unsigned char test[] = { 0x68, 0x07, 0x07, 0x68, 0xFF, 0x80, 0x46, 0x3A, 0x3E, 0x02, 0x00, 0x3F, 0x16 };
	static unsigned char test1[] = { 0xE5 };
	static unsigned char test2[] = { 0xDC, 0x01, 0x02 };
	static unsigned char test3[] = { 0x10, 0x00, 0x00, 0x49, 0x49, 0x16 };
	static unsigned char test4[] = { 0xA2, 0xFF, 0x80, 0x46, 0x3A, 0x3E, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x16 };

	static unsigned char incorrect_msg[] = { 0x12, 0x21 };
	static unsigned char incorrect_SD3[] = { 0xA2, 0xFF, 0x80, 0x2A, 0x3B, 0x3E, 0x02, 0x00, 0x00, 0x00, 0x00, 0x11, 0x12, 0x16 };

	addFrameToContainer<myContainer>(frameVec, test, sizeof(test));
	addFrameToContainer<myContainer>(frameVec, test1, sizeof(test1));
	addFrameToContainer<myContainer>(frameVec, test2, sizeof(test2));
	addFrameToContainer<myContainer>(frameVec, test3, sizeof(test3));
	addFrameToContainer<myContainer>(frameVec, test4, sizeof(test4));
	addFrameToContainer<myContainer>(frameVec, incorrect_msg, sizeof(incorrect_msg));
	addFrameToContainer<myContainer>(frameVec, incorrect_SD3, sizeof(incorrect_SD3));
}
