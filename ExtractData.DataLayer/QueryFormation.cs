using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO = ExtractData.Common.DataTransferObjects;

namespace ExtractData.DataLayer
{
    public class QueryFormation
    {

        public static string FeatureRequestQuery(string sheetName, DTO.FeatureRequestDTO featureReqDTO)
        {
            StringBuilder query = new StringBuilder("Insert Into [" + sheetName + "$] (Feature, [AI Version], [Requested By], Institution, [Requested On], Languages) Values(");

            query.Append("'" + featureReqDTO.Feedback + "',");
            query.Append("'" + featureReqDTO.ProductVersion + "',");
            query.Append("'" + featureReqDTO.Name + "',");
            query.Append("'" + featureReqDTO.Company + "',");
            query.Append("'" + featureReqDTO.RequestedDate + "',");
            query.Append("'" + featureReqDTO.ProductLanguage + "')");

            return query.ToString().Replace("\r\n\r\n", "\r\n").Replace("\r\n\r\n", "\r\n").Replace("\r\n\r\n", "\r\n").Replace("\r\n\r\n", "\r\n").Replace("\r\n;&nbsp", "");
        }

        public static string BugReportQuery(string sheetName, DTO.FeatureRequestDTO featureReqDTO)
        {
            StringBuilder query = new StringBuilder("Insert Into [" + sheetName + "$] (Bug, [AI Version], [Requested By], Institution, [Requested On], Languages, Platform, [Platform Version], [OS Language]) Values(");

            query.Append("'" + featureReqDTO.Feedback + "',");
            query.Append("'" + featureReqDTO.ProductVersion + "',");
            query.Append("'" + featureReqDTO.Name + "',");
            query.Append("'" + featureReqDTO.Company + "',");
            query.Append("'" + featureReqDTO.RequestedDate + "',");
            query.Append("'" + featureReqDTO.ProductLanguage + "',");
            query.Append("'" + featureReqDTO.Platform + "',");
            query.Append("'" + featureReqDTO.OSVersion + "',");
            query.Append("'" + featureReqDTO.OSLanguage + "')");

            return query.ToString().Replace("\r\n\r\n", "\r\n").Replace("\r\n\r\n", "\r\n").Replace("\r\n\r\n", "\r\n").Replace("\r\n\r\n", "\r\n").Replace("\r\n;&nbsp", "");
        }

        public static string MTDataQuery(string sheetName, DTO.MTDataDTO data)
        {
            StringBuilder query = new StringBuilder("Insert Into [" + sheetName + "$] (Product, [Language], [Handoff], [Handoff Date], [Total], [ICE], [Hundred], [Ninety], [Seventy], [Zero], [Repetition]) Values(");

            query.Append("'" + data.Product + "',");
            query.Append("'" + data.ProductLanguage + "',");
            query.Append("'" + data.HandOff + "',");
            query.Append("'" + data.HandOffDate + "',");            
            query.Append("'" + data.Total + "',");
            query.Append("'" + data.ICEMatch + "',");
            query.Append("'" + data.HundredMatch + "',");
            query.Append("'" + data.NinetyMatch + "',");
            query.Append("'" + data.SeventyMatch + "',");
            query.Append("'" + data.ZeroMatch + "',");
            query.Append("'" + data.Repeatitions + "')");

            return query.ToString().Replace("\r\n\r\n", "\r\n").Replace("\r\n\r\n", "\r\n").Replace("\r\n\r\n", "\r\n").Replace("\r\n\r\n", "\r\n").Replace("\r\n;&nbsp", "");
        }

        public static string MTDataReadQuery(string sheetName)
        {
            StringBuilder query = new StringBuilder("SELECT * FROM [" + sheetName + "$]");

            return query.ToString();
        }

    }
}
