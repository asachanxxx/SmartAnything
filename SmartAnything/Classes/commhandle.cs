using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartAnything
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.IO.Ports;

   
        class ClsComHandle
        {
            public SerialPort ComPort1 = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);

            String gernal;
            public void printLCD(int id, string msg)
            {

            }
            public void printDOT(int id, string msg)
            {

                if (msg.Length <= 0)
                {
                    return;
                }
                writeGernal(msg);

                try
                {
                    if (id == 0)
                    {
                        //normal print
                        SendCommandToPrinter(ComPort1, msg);
                    }
                    else if (id == 1)
                    {
                        //centralize normal print
                        char[] chr2 = new char[] { (char)27, (char)97, (char)49 };
                        SendCommandToPrinter(ComPort1, chr2);
                        SendCommandToPrinter(ComPort1, msg);
                        char[] chr3 = new char[] { (char)27, (char)97, (char)48 };
                        SendCommandToPrinter(ComPort1, chr3);
                    }
                    else if (id == 2)
                    {
                        //large print
                        char[] chr = new char[] { (char)27, (char)33, (char)16, (char)31 };
                        SendCommandToPrinter(ComPort1, chr);
                        SendCommandToPrinter(ComPort1, msg);
                        char[] chr1 = new char[] { (char)27, (char)33, (char)0 };
                        SendCommandToPrinter(ComPort1, chr1);
                    }
                    else if (id == 3)
                    {
                        //cetralize large print
                        char[] chr2 = new char[] { (char)27, (char)97, (char)49 };
                        SendCommandToPrinter(ComPort1, chr2);
                        char[] chr = new char[] { (char)27, (char)33, (char)16, (char)31 };
                        SendCommandToPrinter(ComPort1, chr);
                        SendCommandToPrinter(ComPort1, msg);
                        char[] chr1 = new char[] { (char)27, (char)33, (char)0 };
                        SendCommandToPrinter(ComPort1, chr1);
                        char[] chr3 = new char[] { (char)27, (char)97, (char)48 };
                        SendCommandToPrinter(ComPort1, chr3);
                    }
                    else if (id == 10)
                    {
                        //print logo
                        char[] chr2 = new char[] { (char)27, (char)97, (char)49 };
                        SendCommandToPrinter(ComPort1, chr2);
                        char[] chr = new char[] { (char)28, (char)112, (char)1, (char)0 };
                        SendCommandToPrinter(ComPort1, chr);
                        char[] chr3 = new char[] { (char)27, (char)97, (char)48 };
                        SendCommandToPrinter(ComPort1, chr3);
                    }
                    else if (id == 11)
                    {
                        //bar code print
                        char[] chr = new char[] { (char)10, (char)27, (char)64, (char)27, (char)97, (char)1, (char)27, (char)61, (char)1, (char)29, (char)72, (char)3, (char)29, (char)119, (char)2, (char)29, (char)104, (char)50, (char)29, (char)107, (char)69, (char)10 };
                        SendCommandToPrinter(ComPort1, chr);
                        SendCommandToPrinter(ComPort1, msg);
                    }
                    else if (id == 12)
                    {
                        //cut the paper
                        char[] chr = new char[] { (char)27, (char)112, (char)0, (char)100, (char)100, (char)29, (char)114, (char)2 };
                        SendCommandToPrinter(ComPort1, chr);
                    }
                }
                catch (Exception ex) { }

            }

            public static void writeGernal(String msg)
            {
                StreamWriter tw = null;
                try
                {
                    //tw = File.AppendText("C:/Gernal/" + ClsGeneral.sdate.Year + "_" + ClsGeneral.sdate.Month + "_" + ClsGeneral.sdate.Day + ".txt");
                    //tw.WriteLine(msg);
                    //tw.Close();
                }
                catch (Exception)
                {
                    // tw.Close();
                }
            }
            private void SendCommandToPrinter(SerialPort port, string cmd)
            {
                string str = null;
                str = cmd + "\n";
                if (port.IsOpen == true)
                {
                    port.Close();
                }
                port.Open();
                port.Write(str);
                port.Close();
            }

            private void SendCommandToPrinter(SerialPort port, char[] chr)
            {
                if (port.IsOpen == true)
                {
                    port.Close();
                }
                port.Open();
                port.Write(chr, 0, chr.Length);
                port.Close();
            }

        }
    }


