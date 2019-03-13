using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

namespace KClient
{
    [Serializable]
    public class Settings
    {
        [XmlElement("OPCServerURL")]
        public String OPCServerURL { get; set; }

        [XmlElement("TagRamp1")]
        public String TagRamp1 { get; set; }
        [XmlElement("TagRandom1")]
        public String TagRandom1 { get; set; }
        [XmlElement("TagSin1")]
        public String TagSin1 { get; set; }

        [XmlElement("TagRamp2")]
        public String TagRamp2 { get; set; }
        [XmlElement("TagRandom2")]
        public String TagRandom2 { get; set; }
        [XmlElement("TagSin2")]
        public String TagSin2 { get; set; }

        [XmlElement("TagRamp3")]
        public String TagRamp3 { get; set; }
        [XmlElement("TagRandom3")]
        public String TagRandom3 { get; set; }
        [XmlElement("TagSin3")]
        public String TagSin3 { get; set; }

        [XmlElement("TagRamp4")]
        public String TagRamp4 { get; set; }
        [XmlElement("TagRandom4")]
        public String TagRandom4 { get; set; }
        [XmlElement("TagSin4")]
        public String TagSin4 { get; set; }

        public Settings()
        {
            OPCServerURL = "opcda://localhost/Kepware.KEPServerEX.V6";
            TagRamp1 = "Simulation Examples.Functions.Ramp1";
            TagRandom1 = "Simulation Examples.Functions.Random1";
            TagSin1 = "Simulation Examples.Functions.Sine1";

            TagRamp2 = "Simulation Examples.Functions.Ramp2";
            TagRandom2 = "Simulation Examples.Functions.Random2";
            TagSin2 = "Simulation Examples.Functions.Sine2";

            TagRamp3 = "Simulation Examples.Functions.Ramp3";
            TagRandom3 = "Simulation Examples.Functions.Random3";
            TagSin3 = "Simulation Examples.Functions.Sine3";

            TagRamp4 = "Simulation Examples.Functions.Ramp4";
            TagRandom4 = "Simulation Examples.Functions.Random4";
            TagSin4 = "Simulation Examples.Functions.Sine4";
        }

        public String SerializeToString()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(this.GetType());
            StringWriter textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, this);
            return textWriter.ToString();
        }
        public void DeserializeFromString(String stringData)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(this.GetType());
            using (TextReader reader = new StringReader(stringData))
            {
                Settings temp = (Settings)xmlSerializer.Deserialize(reader);

                this.OPCServerURL = temp.OPCServerURL;
                this.TagRamp1 = temp.TagRamp1;
                this.TagRandom1 = temp.TagRandom1;
                this.TagSin1 = temp.TagSin1;

                this.OPCServerURL = temp.OPCServerURL;
                this.TagRamp2 = temp.TagRamp2;
                this.TagRandom2 = temp.TagRandom2;
                this.TagSin2 = temp.TagSin2;

                this.OPCServerURL = temp.OPCServerURL;
                this.TagRamp3 = temp.TagRamp3;
                this.TagRandom3 = temp.TagRandom3;
                this.TagSin3 = temp.TagSin3;

                this.OPCServerURL = temp.OPCServerURL;
                this.TagRamp4 = temp.TagRamp4;
                this.TagRandom4 = temp.TagRandom4;
                this.TagSin4 = temp.TagSin4;
            }
        }
        public void Load()
        {
            String dataFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            dataFile = Path.Combine(dataFile, "settings.dat");
            if (File.Exists(dataFile))
            {
                String serializedString = System.IO.File.ReadAllText(dataFile);
                this.DeserializeFromString(serializedString);
            }
        }
        public void Save()
        {
            String dataFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            dataFile = Path.Combine(dataFile, "settings.dat");
            String serializedString = this.SerializeToString();
            System.IO.File.WriteAllText(dataFile, serializedString);
        }
    }
}
