//Team TooMuchRecursion, Team Cat With No Legs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace HackathonTcpClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("67.202.15.69", 45444);
            try
            {
                NetworkStream s = client.GetStream();
                StreamReader sr = new StreamReader(s);
                StreamWriter sw = new StreamWriter(s);
                sw.AutoFlush = true;
                // Console.WriteLine(sr.ReadLine());

                int wna = 0;
                int weu = 0;
                int wap = 0;
                int jna = 0;
                int jeu = 0;
                int jap = 0;
                int dna = 0;
                int deu = 0;
                int dap = 0;

                List<string> dataStore = new List<string>(); //
                string stringBuffer = "";

                string input = "INIT TooMuchRecursion";
                char[] buffer = new char[128];
                sw.Write(input);
                sr.Read(buffer, 0, 128);
                stringBuffer = new string(buffer); //
                dataStore.Add(stringBuffer);
                Console.WriteLine(new string(buffer));
                Array.Clear(buffer, 0, buffer.Length);
                input = "RECD";
                sw.Write(input);
                sr.Read(buffer, 0, 128);
                stringBuffer = new string(buffer); //
                dataStore.Add(stringBuffer);
                Console.WriteLine(new string(buffer));
                Array.Clear(buffer, 0, buffer.Length);
                input = "START";
                sw.Write(input);
                sr.Read(buffer, 0, 128);
                stringBuffer = new string(buffer); //
                dataStore.Add(stringBuffer);
                Console.WriteLine(new string(buffer));
                Array.Clear(buffer, 0, buffer.Length);
                int turncount = 0;
                while (input != "EXIT")
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        input = "RECD";
                        sw.Write(input);
                        sr.Read(buffer, 0, 128);
                        stringBuffer = new string(buffer); //
                        dataStore.Add(stringBuffer);
                        Console.WriteLine(new string(buffer));
                        Array.Clear(buffer, 0, buffer.Length);
                    }





                    char[] output = ("CONTROL  0  0  0  0  0  0  0  0  0").ToCharArray();

                    string servstr = dataStore[dataStore.Count - 4];   //string splits
                    string[] serv = servstr.Split(' ');

                    string prestring = dataStore[dataStore.Count - 3];
                    string[] demand = prestring.Split(' ');

                    string curstring = dataStore[dataStore.Count - 2];
                    string[] dist = curstring.Split(' ');

                    string prostring = dataStore[dataStore.Count - 1];
                    string[] profit = prostring.Split(' ');


                    long indemand = Convert.ToInt64(dist[dist.Length - 9]);   //wna
                    double servnum1 = Convert.ToDouble(serv[serv.Length - 9]);
                    if (servnum1 != 0)
                    {
                        if ((indemand / servnum1) >= 160.0)
                        {
                            output[9] = '1';
                            wna = wna + 1;
                        }
                        else if (((indemand / servnum1) < 150.0) && (wna - 1 > 0))
                        {
                            output[8] = '-';
                            output[9] = '1';
                            wna = wna - 1;
                        }
                        else
                            output[9] = '0';
                    }
                    else
                    {
                        if (indemand >= 160.0)
                        {
                            output[9] = '1';
                            wna = wna + 1;
                        }
                        else
                            output[9] = '0';
                    }


                    indemand = Convert.ToInt64(dist[dist.Length - 8]);   //weu
                    servnum1 = Convert.ToDouble(serv[serv.Length - 8]);
                    if (servnum1 != 0)
                    {
                        if ((indemand / servnum1) >= 160.0)
                        {
                            output[12] = '1';
                            weu = weu + 1;
                        }
                        else if (((indemand / servnum1) < 150.0) && (weu - 1 > 0))
                        {
                            output[11] = '-';
                            output[12] = '1';
                            weu = weu - 1;
                        }
                        else
                            output[12] = '0';
                    }
                    else
                    {
                        if (indemand >= 160.0)
                        {
                            output[12] = '1';
                            weu = weu + 1;
                        }
                        else
                            output[12] = '0';
                    }


                    indemand = Convert.ToInt64(dist[dist.Length - 7]);   //wap
                    servnum1 = Convert.ToDouble(serv[serv.Length - 7]);
                    if (servnum1 != 0)
                    {
                        if ((indemand / servnum1) >= 160.0)
                        {
                            output[15] = '1';
                            wap = wap + 1;
                        }
                        else if (((indemand / servnum1) < 150.0) && (wap - 1 > 0))
                        {
                            output[14] = '-';
                            output[15] = '1';
                            wap = wap - 1;
                        }
                        else
                            output[15] = '0';
                    }
                    else
                    {
                        if (indemand >= 160.0)
                        {
                            output[15] = '1';
                            wap = wap + 1;
                        }
                        else
                            output[15] = '0';
                    }
///////
                    indemand = Convert.ToInt64(dist[dist.Length - 6]);   //jna
                    servnum1 = Convert.ToDouble(serv[serv.Length - 6]);
                    if (servnum1 != 0)
                    {
                        if ((indemand / servnum1) >= 350.0)
                        {
                            output[18] = '1';
                            jna = jna + 1;
                        }
                        else if (((indemand / servnum1) < 240.0) && (jna - 1 > 0))
                        {
                            output[17] = '-';
                            output[18] = '1';
                            jna = jna - 1;
                        }
                        else
                            output[18] = '0';
                    }
                    else
                    {
                        if (indemand >= 350.0)
                        {
                            output[18] = '1';
                            jna = jna + 1;
                        }
                        else
                            output[18] = '0';
                    }

 ///////
                    indemand = Convert.ToInt64(dist[dist.Length - 5]);   //jeu
                    servnum1 = Convert.ToDouble(serv[serv.Length - 5]);
                    if (servnum1 != 0)
                    {
                        if ((indemand / servnum1) >= 350.0)
                        {
                            output[21] = '1';
                            jeu = jeu + 1;
                        }
                        else if (((indemand / servnum1) < 240.0) && (jeu - 1 > 0))
                        {
                            output[20] = '-';
                            output[21] = '1';
                            jeu = jeu - 1;
                        }
                        else
                            output[21] = '0';
                    }
                    else
                    {
                        if (indemand >= 350.0)
                        {
                            output[21] = '1';
                            jeu = jeu + 1;
                        }
                        else
                            output[21] = '0';
                    }

 ///////
                    indemand = Convert.ToInt64(dist[dist.Length - 4]);   //jap
                    servnum1 = Convert.ToDouble(serv[serv.Length - 4]);
                    if (servnum1 != 0)
                    {
                        if ((indemand / servnum1) >= 350.0)
                        {
                            output[24] = '1';
                            jap = jap + 1;
                        }
                        else if (((indemand / servnum1) < 240.0) && (jap - 1 > 0))
                        {
                            output[23] = '-';
                            output[24] = '1';
                            jap = jap - 1;
                        }
                        else
                            output[24] = '0';
                    }
                    else
                    {
                        if (indemand >= 350.0)
                        {
                            output[24] = '1';
                            jap = jap + 1;
                        }
                        else
                            output[24] = '0';
                    }


 ///////
                    indemand = Convert.ToInt64(dist[dist.Length - 3]);   //dna
                    servnum1 = Convert.ToDouble(serv[serv.Length - 3]);
                    if ((servnum1 != 0) && (dna < 2))
                    {
                        if ((indemand / servnum1) >= 1020.0)
                        {
                            output[27] = '1';
                            dna = dna + 1;
                        }
                        else if (((indemand / servnum1) < 810.0) && (dna - 1 > 0))
                        {
                            output[26] = '-';
                            output[27] = '1';
                            dna = dna - 1;
                        }
                        else
                            output[27] = '0';
                    }
                    else
                    {
                        if ((indemand >= 350.0) && (dna < 2))
                        {
                            output[27] = '1';
                            dna = dna + 1;
                        }
                        else
                            output[27] = '0';
                    }



                        ///////
                        indemand = Convert.ToInt64(dist[dist.Length - 2]);   //deu
                        servnum1 = Convert.ToDouble(serv[serv.Length - 2]);
                        if ((servnum1 != 0) && (deu < 1))
                        {
                            if ((indemand / servnum1) >= 1020.0)
                            {
                                output[30] = '1';
                                deu = deu + 1;
                            }
                            else if (((indemand / servnum1) < 810.0) && (deu - 1 > 0))
                            {
                                output[29] = '-';
                                output[30] = '1';
                                deu = deu - 1;
                            }
                            else
                                output[30] = '0';
                        }
                        else
                        {
                            if ((indemand >= 350.0) && (deu < 1))
                            {
                                output[30] = '1';
                                deu = deu + 1;
                            }
                            else
                                output[30] = '0';
                        }


  ///////
                        indemand = Convert.ToInt64(dist[dist.Length - 1]);   //dap
                        servnum1 = Convert.ToDouble(serv[serv.Length - 1]);
                        if ((servnum1 != 0) && (dap < 2))
                        {
                            if ((indemand / servnum1) >= 1020.0)
                            {
                                output[33] = '1';
                                dap = dap + 1;
                            }
                            else if (((indemand / servnum1) < 810.0) && (dap - 1 > 0))
                            {
                                output[32] = '-';
                                output[33] = '1';
                                dap = dap - 1;
                            }
                            else
                                output[33] = '0';
                        }
                        else
                        {
                            if ((indemand >= 350.0) && (dap < 2))
                            {
                                output[33] = '1';
                                dap = dap + 1;
                            }
                            else
                                output[33] = '0';
                        }

                    Console.WriteLine(new string(output));
                    sw.Write(new string(output));

                    Console.ReadLine();


                    sr.Read(buffer, 0, 128);
                    stringBuffer = new string(buffer); //
                    dataStore.Add(stringBuffer);
                    if (stringBuffer == "END")
                    {
                        input = "STOP";
                        sw.Write(input);
                        input = "EXIT";
                    }
                    Console.WriteLine(new string(buffer));
                    Array.Clear(buffer, 0, buffer.Length);
                    turncount++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Press <Enter> to close program.");
            Console.ReadLine();
        }
    }
}