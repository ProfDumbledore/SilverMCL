using System;
using System.Text;
using Crestron.SimplSharp;      // For Basic SIMPL# Classes
using Crestron.SimplSharp.CrestronXml;
using Crestron.SimplSharp.CrestronXmlLinq;
using Crestron.SimplSharp.CrestronIO;




namespace MCLsharp
{
    public class Reader
    {
        string strPath = "\\NVRAM\\today.xml";



        public Reader()
        {
        }

        public void Go()
        {
            int x = 0;
   
            var myStream = new FileStream(strPath, FileMode.Open);

            var myXMLReader = new XmlReader(myStream);

            while (myXMLReader.Read())

            {

            x = x++;

            if (x > 400)

            throw new Exception("Looped 400 Times failed to EOF");

            switch (myXMLReader.NodeType)

            {

            case XmlNodeType.Element:

            switch (myXMLReader.Name.ToLower())

            {

            case "book":

            if (myXMLReader.HasAttributes)

            {

            while (myXMLReader.MoveToNextAttribute())

            {

            if (myXMLReader.Name.ToLower() == "id")

            CrestronConsole.PrintLine("ID: {0}", myXMLReader.Value);

            }

            }

            break;

            case "author":

            case "title":

            case "genre":

            case "description":

            CrestronConsole.PrintLine("{0}: {1}", myXMLReader.Name, myXMLReader.ReadString());

            break;

            }

            break;

            default:

            break;

            }
        
        }
    }
}
}
