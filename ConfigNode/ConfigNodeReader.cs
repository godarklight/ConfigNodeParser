using System;
using System.IO;
using System.Text;

namespace ConfigNodeParser
{
    public class ConfigNodeReader
    {
        public static ConfigNode StringToConfigNode(string inputString)
        {
            ConfigNode returnNode = new ConfigNode();
            using (StringReader sr = new StringReader(inputString))
            {
                int objectLevel = 0;
                string passName = "";
                StringBuilder passData = null;
                string previousLine = null;
                string currentLine = null;
                while ((currentLine = sr.ReadLine()) != null)
                {
                    string trimmedLine = currentLine.TrimStart();
                    //Take note of depth
                    if (trimmedLine == "{")
                    {
                        objectLevel++;
                        //Started reading a config node block
                        if (objectLevel == 1)
                        {
                            passName = previousLine;
                            passData = new StringBuilder();
                            continue;
                        }
                    }
                    if (trimmedLine == "}")
                    {
                        objectLevel--;
                        if (objectLevel == 0)
                        {
                            //Finished reading a config node block
                            ConfigNode newNode = StringToConfigNode(passData.ToString());
                            newNode.name = passName;
                            returnNode.AddConfigNode(newNode);
                            passName = null;
                            passData = null;
                            continue;
                        }
                    }
                    if (objectLevel == 0)
                    {
                        //We are reading a config node at our depth
                        if (trimmedLine.Contains(" = "))
                        {
                            string pairKey = trimmedLine.Substring(0, trimmedLine.IndexOf(" = "));
                            string pairValue = trimmedLine.Substring(trimmedLine.IndexOf(" = ") + 3);
                            returnNode.AddValue(pairKey, pairValue);
                        }
                    }
                    else
                    {
                        //We are reading a different node
                        passData.AppendLine(currentLine);
                    }
                    previousLine = trimmedLine;
                }
            }
            return returnNode;
        }

        public static ConfigNode FileToConfigNode(string inputFile)
        {
            string configNodeText = File.ReadAllText(inputFile);
            return StringToConfigNode(configNodeText);
        }
    }
}

