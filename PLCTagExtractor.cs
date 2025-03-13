using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using Logix; 

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Initialize controller and set IP address
                Controller MyPLC = new Controller
                {
                    IPAddress = "10.10.205.43"
                };

                // Connect to the PLC
                if (MyPLC.Connect() != ResultCode.E_SUCCESS)
                {
                    Console.WriteLine(MyPLC.ErrorString);
                    return;
                }

                // Upload the tags from the PLC
                if (MyPLC.UploadTags() != ResultCode.E_SUCCESS)
                {
                    Console.WriteLine(MyPLC.ErrorString);
                    return;
                }

                // Create XML structure for the output
                XElement plcXml = new XElement("PLC",
                    new XAttribute("IPAddress", MyPLC.IPAddress));

                // Get the list of programs in the PLC
                ReadOnlyCollection<Logix.Program> programList = MyPLC.ProgramList;

                // Iterate through each program and capture tags
                foreach (Logix.Program program in programList)
                {
                    XElement programXml = new XElement("Program",
                        new XAttribute("Name", program.Name));

                    // Get list of TagTemplates for each program
                    ReadOnlyCollection<TagTemplate> templateList = program.TagItems();

                    foreach (TagTemplate item in templateList.ToList())
                    {
                        XElement tagXml = new XElement("Tag",
                            new XAttribute("Name", item.Name),
                            new XAttribute("DataType", item.TypeName));

                        // Check for child tags (members of UDTs)
                        if (!item.IsAtomic)
                        {
                            foreach (TagTemplate child in item.Members.ToList())
                            {
                                XElement childTagXml = new XElement("Member",
                                    new XAttribute("Name", child.Name),
                                    new XAttribute("DataType", child.TypeName));

                                tagXml.Add(childTagXml);
                            }
                        }

                        programXml.Add(tagXml);  // Add tag to the program XML
                    }

                    plcXml.Add(programXml);  // Add the program XML to the root PLC element
                }

                // Save the XML to a file
                plcXml.Save("PLC_Tags.xml");

                Console.WriteLine("Tag structure saved to PLC_Tags.xml");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
            }
        }
    }
}
