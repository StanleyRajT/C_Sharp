using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination
{/// <summary>
/// stores beneficiary details
/// Object(string Name,long mobile,string address,int age,int gender)
/// </summary>
    class BeneficiaryDetails
    {
        private static int _autoIncreamentedNumber = 1001;
        public int RegistrationID { get; set; }
        public string Name { get; set; }
        public long Mobile { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public GenderChoice Gender { get; set; }
        public List<VaccineDetails> VaccinatedDetails = new List<VaccineDetails>();

        public BeneficiaryDetails(string name, long mobile, string address, int age, int gender)
        {
            RegistrationID = _autoIncreamentedNumber++;
            Name = name;
            Mobile = mobile;
            Address = address;
            Age = age;
            Gender = (GenderChoice)gender;

        }
        /// <summary>
        /// Vaccinate method helps to vaccinate the beneficiary
        /// </summary>
        /// <param name="vaccine"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public string Vaccinate(int vaccine, DateTime date)
        {
            string message = null;

            if (VaccinatedDetails.Count == 0)
            {
                VaccineDetails details = new(vaccine, date, 1);
                VaccinatedDetails.Add(details);
                message = $"Your Next dose due time is {details.VaccinatedDate.AddDays(30).ToString("dd/MM/yyyy")}.";

            }
            else if (VaccinatedDetails.Count == 1)
            {
                if (date > VaccinatedDetails[0].VaccinatedDate.AddDays(30))
                {
                    VaccineDetails details = new(vaccine, date, 2);
                    VaccinatedDetails.Add(details);
                    message = "You have completed the vaccination course. Thanks for your participation in the vaccination drive.";
                    return message;
                }
                else
                {
                    message = $"You are not allowed for 2nd dose your due date is {VaccinatedDetails[0].VaccinatedDate.AddDays(30).ToString("dd/MM/yyyy")}.";
                    return message;
                }
            }


            return message;
        }
        /// <summary>
        /// DueDate method helps to show the due date of the beneficiaries
        /// </summary>
        /// <returns></returns>
        public string DueDate()
        {
            string message = null;
            if (VaccinatedDetails.Count == 0)
            {
                message = "please take your vaccination First!!!. ";
                return message;
            }
            else if (VaccinatedDetails.Count == 1)
            {

                message = $"Your Next dose due time is {VaccinatedDetails[0].VaccinatedDate.AddDays(30).ToString("dd/MM/yyyy")}.";
                return message;

            }
            else
            {
                message = "You have completed the vaccination course. Thanks for your participation in the vaccination drive.";
                return message;
            }
        }

    }
    /// <summary>
    ///   To choose gender(Male,Female,Transgender)
    /// </summary>
    public enum GenderChoice
    {
        Male = 1, Female, Transgender
    }
}
