using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.BaseLayer.Setting
{
    public class SettingBase
    {

    }
    public class watchbase
    {
        public int ID { get; set; }
        public string watch { get; set; }
    }

    public class DepartmentTypeBase
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }

    public class LicenseTypeBase
    {
        public int LicenseID { get; set; }
        public string LicenseName { get; set; }
    }

    public class LicenseStatusBase
    {
        public int ID { get; set; }
        public string LicenseStatus { get; set; }
    }

    public class FeatureTypeBase
    {
        public int ID { get; set; }
        public string FeatureType { get; set; }
    }

    public class FeatureLocationBase
    {
        public int ID { get; set; }
        public string FLocation { get; set; }
    }

    public class ComplexionBase
    {
        public int ID { get; set; }
        public string Complexion { get; set; }
    }

    public class BuildBase
    {
        public int ID { get; set; }
        public string Build { get; set; }
    }

    public class HairLengthBase
    {
        public int ID { get; set; }
        public string HairLength { get; set; }
        public string ImagePath { get; set; }
    }
    public class MasterTypeID
    {
        public int ID { get; set; }
        public string Value { get; set; } 
    }
    public class HairColorBase
    {
        public int ID { get; set; }
        public string HairColor { get; set; }
    }

    public class FacialHairBase
    {
        public int ID { get; set; }
        public string FacialHair { get; set; }
    }

    public class RaceBase
    {
        public int ID { get; set; }
        public string Race { get; set; }
    }

    public class EyesBase
    {
        public int ID { get; set; }
        public string Eyes { get; set; }
    }

    public class SexBase
    {
        public int ID { get; set; }
        public string Sex { get; set; }
    }

    public class ShortDescriptorBase
    {
        public int ID { get; set; }
        public int NatureID { get; set; }
        public string Descriptor { get; set; }
        public string ProShortDescriptor { get; set; }
    }

    public class NatureofIncidentBase
    {
        public int ID { get; set; }
        public int NatureType { get; set; }
        public string Nature { get; set; }
        public string NatureImage { get; set; }
    }

    public class StatusBase
    {
        public int ID { get; set; }
        public string Status { get; set; }
    }

    public class RoleBase
    {
        public int ID { get; set; }
        public string Role { get; set; }
    }

    public class GameBase
    {
        public int ID { get; set; }
        public string Game { get; set; }
    }
    public class BuyInGameBase
    {
        public int ID { get; set; }
        public string Game { get; set; }
    }
    public class CashoutTableNumberBase
    {
        public int ID { get; set; }
        public string TableNumber { get; set; }
    }
    public class DisputeTypeBase
    {
        public int ID { get; set; }
        public string DisputeType { get; set; }
    }
    public class BuyInPitTypeBase
    {
        public int ID { get; set; }
        public string BuyInPitType { get; set; }
    }
    public class CashierBase
    {
        public int ID { get; set; }
        public string Cashier { get; set; }
    }
    public class LocationBase
    {
        public int ID { get; set; }
        public string Location { get; set; }
    }
    public class ResolutionBase
    {
        public int ID { get; set; }
        public string Resolution { get; set; }
    }
    public class VehicleColorBase
    {
        public int ID { get; set; }
        public string Color { get; set; }
    }
    public class AuthorizedByBase
    {
        public int ID { get; set; }
        public string AuthorizedBy { get; set; }
    }
    public class TypeofBan
    {
        public int ID { get; set; }
        public string BanType { get; set; }
    }
    public class EmployeePositionBase
    {
        public int ID { get; set; }
        public string Position { get; set; }
    }

    public class AddressTypeBase
    {
        public int ID { get; set; }
        public string AddressType { get; set; }
    }
    public class VarianceTypeBase
    {
        public int ID { get; set; }
        public string VarianceType { get; set; }
    }

    public class VarianceResolutionBase
    {
        public int ID { get; set; }
        public string Resolution { get; set; }
    }

    public class AliasNameTypeBase
    {
        public int ID { get; set; }
        public string NameType { get; set; }
    }

    public class ForeignExchangeRatesBase
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string Rate { get; set; }
    }

    public class ServicesBase
    {
        public int ID { get; set; }
        public string ServiceName { get; set; }
        public string DeclinedAvailable { get; set; }
    }

    public class EquipmentStatusBase
    {
        public int ID { get; set; }
        public string Problems { get; set; }
    }

    public class EquipmentActionBase
    {
        public int ID { get; set; }
        public string Actions { get; set; }
    }

    public class InitiatedByBase
    {
        public int ID { get; set; }
        public string Initiated { get; set; }
    }

    public class NatureEventBase
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string DefaultAction { get; set; }
        public string DefaultCamera { get; set; }
    }

    public class SetMetricsBase
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Metrics { get; set; }
        public bool ActiveMetrics { get; set; }
    }

    public class LogoImageBase
    {
        public int ImageID { get; set; }
        public string ImagePath { get; set; }
        public bool SetImage { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedAt { get; set; }
    }

    public class EmailLogBase
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string SMTP { get; set; }
        public string Password { get; set; }
        public string CreatedBy { get; set; }
    }

    //Ankur new 1   
    public class Incedent_Pref
    {
        public int ID { get; set; }
        public string pref_Type { get; set; }
        public string pref_Value { get; set; }
    }
    public class AuditsQuestionsVM
    {
        public int QuestionID { get; set; }
        public int AuditID { get; set; }
        public byte QuestionType { get; set; }
        public string Question { get; set; }
        public string ToolTip { get; set; }
        public string Audit { get; set; }
    }
    public class WeightUnitBase
    {
        public int WeightUnitId { get; set; }
        public string WeightUnitName { get; set; }
        public bool IsDefault { get; set; }
    }

    public class HeightUnitBase
    {
        public int HeightUnitId { get; set; }
        public string HeightUnitName { get; set; }
        public bool IsDefault { get; set; }
    }

    public class FileType
    {
        public int FileTypeId { get; set; }
        public string Name { get; set; }
      
    }
}
