using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml.Serialization;

namespace ExtractData.Common.DataTransferObjects
{
    [XmlRoot(Namespace = "")]
    public class DataList
    {
        public List<testcase> testcaselist;
    }

    public class testcase
    {
        [XmlElement("displayid")]
        public string displayid;

        public List<tcstep> tcsteplist;
    }

    public class tcstep
    {
        [XmlElement("desc")]
        public string desc;

        [XmlElement("exresult")]
        public string exresult;
    }

}
