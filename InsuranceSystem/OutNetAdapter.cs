namespace Unit5_AdapterPatternPatient_Blazor.InsuranceSystem
{
    public class OutNetAdapter : InsuranceInterface
    {
        OutNetworkPatient patient;
        public OutNetAdapter(string newName, int newPolicyNumber) {
            patient = new OutNetworkPatient(newName,newPolicyNumber);
        }
        public decimal CoverageAmount(int ProcedureID, decimal ProcedureCost)
        {
            decimal coveragePercent = patient.CoveragePercent(ProcedureCost);
            return (coveragePercent * ProcedureCost);
        }

        public string getPatientName()
        {
            return patient.getPatientName(); 
        }

        public string getPolicyNumber()
        {
            return patient.PolicyNumber.ToString();
        }

        public bool IsCovered(string patientName, string policyNumber)
        {
            int number = int.Parse(policyNumber);
            string covered = patient.IsCovered(patientName, number);
            if (covered == "Covered" && patient.Name == patientName && patient.PolicyNumber == number)
            {
                return true;
            }

            return false;

        }
    }
}
