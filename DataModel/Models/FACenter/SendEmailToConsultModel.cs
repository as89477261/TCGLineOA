using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.FACenter
{
    public class SendEmailToConsultModel
    {
        [AlphaFormatValidateField] public string Id { get; set; }

        [AlphaFormatValidateField] public string Ref1 { get; set; }

        public string Ref2 { get; set; }

    }

}
