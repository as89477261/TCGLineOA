using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.NCB
{
    public class NCBTransactionDataModel
    {
     public string ReferID{get;set;}
     public string ReferIDType{get;set;}
     public string ReferDB{get;set;}
     public string Param1{get;set;}
     public string Param2{get;set;}
     public string Param3{get;set;}
     public string Param4{get;set;}
     public string Param5{get;set;}
     public string Param6{get;set;}
     public string RequestAccount{get;set;}
     public string RequestType{get;set;}
     public string T01Online_ID{get;set;}
     public string TransID{get;set;}
     public string Channel{get;set;}
     public string MemberRef{get;set;}
     public string ResponseBody{get;set;}
     public decimal T01NCBScore{get;set;}
     public string T01NCBGrade{get;set;}
     public string UpdateStatus{get;set;}
     public DateTime CreatedDate{get;set;}
    }
}
