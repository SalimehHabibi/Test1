using System.Configuration;
namespace EducationDegree.POL
{
    partial class EducationDegreeDataContext
    {
        public EducationDegreeDataContext()
            : base(ConfigurationManager.ConnectionStrings["post"].ConnectionString, mappingSource)
{
OnCreated();
}
    }
}
