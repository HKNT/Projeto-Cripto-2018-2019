using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoCriptografia
{
    class Program
    {
        private char[]          vChar;
        private  int[]       vInteiro;
        private  int[]   iCriptografa;
        private  int[] iDecriptografa;

        public Program(String message)
        {
            vChar          =    message.ToCharArray();
            vInteiro       = new int   [vChar.Length];
            iCriptografa   = new int   [vChar.Length];
            iDecriptografa = new int   [vChar.Length];
        }

        public String criptografaMensagem()
        {
            String sDecimalMessage = ""; // variavel de validacao
            String sMessageCrip    = ""; // variavel de validacao


            //=-----------Populando o vInteiro com decimais da mensagem
            for (int i=0; i<vChar.Length; i++)
            {
                vInteiro[i]      = (int)vChar[i];
                sDecimalMessage +=   vInteiro[i];
            }

            //=-----------Processo de criptografia
            for (int i = 0; i < vInteiro.Length; i++)
            {
                iCriptografa[i] = (vInteiro[i] * 2);
                sMessageCrip   +=   iCriptografa[i];
            }
            return sMessageCrip;
        }//criptografaMensagem

        public String descriptografaMensagem()
        {
            String sMessageDecrip  = "";
            String sDecimalMessage = "";
            for (int i=0; i<iCriptografa.Length; i++)
            {
                iDecriptografa[i] = (iCriptografa[i] / 2);
                sMessageDecrip   +=     iDecriptografa[i];
            }

            for (int i = 0; i < iCriptografa.Length; i++)
            {
                vChar[i]         = (char)iDecriptografa[i];
                sDecimalMessage +=                vChar[i];
            }
            return sDecimalMessage;
        }//descriptografaMensagem

        //cria um arquivo de texto.
        public void writerFileText(String router, String message)
        {
            try
            {
                StreamWriter sw = new StreamWriter(router, true, Encoding.Default);
                sw.WriteLine(message);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Writer File Text");
                Console.Write(e.GetBaseException());
                Environment.Exit(1);
            }
        }//writerFileText
        
        /*
        static void Main(string[] args)
        {
            String messageUser = "2";

            Program obj = new Program(messageUser);



            Console.WriteLine("Mensagem Criptografada:    " + obj.criptografaMensagem()   );
            Console.WriteLine("Mensagem Descriptografada: " + obj.descriptografaMensagem());
            Console.ReadKey();
        }// Main
        */

    }//Program
}//nameSpace

namespace AbrindoArquivoTexto{

    class WorkFileText
    {
        
        //le o arquivo de texto
        public String readFileText(String router)
        {
            String textFile = "";

            try
            {
                textFile = File.ReadAllText(router, Encoding.Default);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao ler o arquivo");
                Console.Write(e.GetBaseException());
                Environment.Exit(1);
            }
            return textFile;
        }//readFileText

        public String tratativa(String txt) // Esta tratativa é um metodo que eu estou tentando desenvolver para recuperar o que esta no arquivo
        {            
            char[] vChar     = txt.ToCharArray();
            String[] vString = new string[txt.Length];
            int [] vInteiro  = new int[vChar.Length];
            String aux = "";

            for(int i=0; i < vChar.Length; i++)
            {                
                vInteiro[i] = (int)vChar[i];
                vChar[i] = (char)vInteiro[i];
                aux += vChar[i];
            } 
            return aux;
        }
        
        static void Main(string[] args)
        {
            WorkFileText obj   = new WorkFileText();
            //String desktop     = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\Cifra.txt";            
            Console.WriteLine(obj.tratativa("120"));                       

            Console.ReadKey();
        }//Main
        


        }//Class
}//namespace
