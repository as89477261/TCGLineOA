using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public class RespondAPIMemberStatusBYSModel
{
    public bool Success { get; set; }
    public string Code { get; set; }
    public string Key { get; set; }
    public string Message { get; set; }
    public string Description { get; set; }
    public string TransactionId { get; set; }
    public string TransactionDateTime { get; set; }
    public Items Items { get; set; }
    public object OtherItems { get; set; }
}

public class Items
{
    public string MemberRegisno { get; set; }
    public string MemberType { get; set; }
    public string MemberTaxId { get; set; }
    public string MemberCompanyType { get; set; }
    public string MemberTName { get; set; }
    public string MemberEName { get; set; }
    public string MemberFirstName { get; set; }
    public string MemberLastName { get; set; }
    public string MemberLineID { get; set; }
    public string MemberCard {  get; set; }
    public string MemberImage { get; set; }
    public bool isTCG { get; set; }


	public List<MemberGroup> MemberGroupList { get; set; }
}

public class MemberGroup
{
    public string MemberGroupCode { get; set; }
    public string MemberShortName { get; set; }

    public string MemberGroupName { get; set; }
    public int MemberGroupPCCFlag { get; set; }
    public string MemberGroupPCCName { get; set; }
    public string MemberGroupStatus { get; set; }
    public DateTime? MemberGroupEffectiveDate { get; set; }
    public DateTime? MemberGroupExpireDate { get; set; }
    public DateTime? GMemberResignDate { get; set; }
    public string MemberGroupValue { get; set; }
    public string MemberStatus { get; set; }
    public string MemberStatusDesc { get; set; }
}


public class RequestAPIMemberStatusBYSModel
{
    public string memberRegisno { get; set; }

}


public class ItemAddMember
{
    public string RegisterNo { get; set; }
    public bool IsSave { get; set; }
    public string Status { get; set; }
    public bool MemberStatus { get; set; }
}

public class ResponseModelAddMember
{
    public bool Success { get; set; }
    public string Code { get; set; }
    public string Key { get; set; }
    public string Message { get; set; }
    public string Description { get; set; }
    public string TransactionId { get; set; }
    public string TransactionDateTime { get; set; }
    public List<ItemAddMember> Items { get; set; }
    public object OtherItems { get; set; }
}

public class Address
{
    public string AddressNoTH { get; set; }
    public string MooTH { get; set; }
    public string BuildingTH { get; set; }
    public string VillageTH { get; set; }
    public string FloorTH { get; set; }
    public string RoomTH { get; set; }
    public string SoiTH { get; set; }
    public string LaneTH { get; set; }
    public string RoadTH { get; set; }
    public string TambolTH { get; set; }
    public string AmphurTH { get; set; }
    public string ProvinceTH { get; set; }
    public string CountryTH { get; set; }
    public string FullAddressTH { get; set; }
    public string AddressNoEN { get; set; }
    public string MooEN { get; set; }
    public string BuildingEN { get; set; }
    public string VillageEN { get; set; }
    public string FloorEN { get; set; }
    public string RoomEN { get; set; }
    public string SoiEN { get; set; }
    public string LaneEN { get; set; }
    public string RoadEN { get; set; }
    public string CountryEN { get; set; }
    public string FullAddressEN { get; set; }
    public string Zipcode { get; set; }
}

public class Document
{
    public string DocumentType { get; set; }
    public string File { get; set; }
}

public class ListDataPerson
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string RegisterNo { get; set; }
    public string IssueDate { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public string Occupation { get; set; }
    public string ProductName { get; set; }
    public string ProductExportCountry { get; set; }
    public string BussinessType { get; set; }
    public string ProductNameExport { get; set; }
    public Address Address { get; set; }
    public List<Document> Document { get; set; }
}

public class RootAddPerson
{
    public List<ListDataPerson> listData { get; set; }

}

public class ListDataJurustic
{
    public string CompanyName { get; set; }
    public string RegisterNo { get; set; }
    public string IssueDate { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public string CompanyType { get; set; }
    public string ProductName { get; set; }
    public string BussinessType { get; set; }
    public string NumberEmployee { get; set; }
    public string ProductExportCountry { get; set; }
    public string ProductNameExport { get; set; }
    public string ContactFirstName { get; set; }
    public string ContactLastName { get; set; }
    public string ContactIDCard { get; set; }
    public string ContactPosition { get; set; }
    public string ContactMobile { get; set; }
    public string ContactEmail { get; set; }
    public string DirectorFirstName { get; set; }
    public string DirectorLastName { get; set; }
    public string DirectorIDCard { get; set; }
    public string DirectorMobile { get; set; }
    public string DirectorEmail { get; set; }
    public string DirectorIDCopyDoc { get; set; }
    public decimal TotalAsset { get; set; }
    public Address Address { get; set; }
    public List<Document> Document { get; set; }
}

public class RootAddJurustic
{
    public List<ListDataJurustic> listData { get; set; }

}

public class FileUploadResponse
{
    public string Uid { get; set; }
    public string Url { get; set; }
    public string FileType { get; set; }
}
