using System;
using System.Data;
using System.Data.SqlClient;

namespace ParseJSON.DataClasses
{
    public abstract class Skill
    {
        public Skill(string values, int rowindex)
        {
            ParseString(values, rowindex);
        }

        public int SkillID { get; set; }
        public int SkillJD { get; set; }
        public int SOrder { get; set; }
        public int SOrderJp { get; set; }
        public string SkillEn { get; set; }
        public string SkillJp { get; set; }
        public string ParentEn { get; set; }
        public string ParentJp { get; set; }
        public string EffectEn { get; set; }
        public string EffectJp { get; set; }
        public string MemoEn { get; set; }
        public string ErrorEn { get; set; }
        public string SkillOrb { get; set; }
        public int MaxCD { get; set; }
        public int MinCD { get; set; }
        public int LevelCap { get; set; }
        public int SeriesID { get; set; }
        public int GroupID { get; set; }
        public int Special1 { get; set; }
        public int Special2 { get; set; }
        public int Special3 { get; set; }
        public int Special4 { get; set; }
        public int Special5 { get; set; }
        public int Special6 { get; set; }
        public int Special7 { get; set; }
        public int Special8 { get; set; }
        public bool SkillContainer { get; set; }
        public bool SkillSecondary { get; set; }
        public int SkillParentID { get; set; }
        public string MemoJp { get; set; }
        public string ErrorJp { get; set; }
        public string SkillOrbJp { get; set; }
        public int MaxCDJp { get; set; }
        public int MinCDJp { get; set; }
        public int LevelCapJp { get; set; }
        public int SeriesIDJp { get; set; }
        public int GroupIDJp { get; set; }
        public int Special1Jp { get; set; }
        public int Special2Jp { get; set; }
        public int Special3Jp { get; set; }
        public int Special4Jp { get; set; }
        public int Special5Jp { get; set; }
        public int Special6Jp { get; set; }
        public int Special7Jp { get; set; }
        public int Special8Jp { get; set; }
        public bool SkillContainerJp { get; set; }
        public bool SkillSecondaryJp { get; set; }
        public int SkillParentIDJp { get; set; }


        protected abstract void ParseString(string values, int rowindex);
        protected abstract string CreateSQL();

        public static bool IgnoreRow(string value, out bool increaseRowCount)
        {
            increaseRowCount = !(value.Trim().StartsWith("{") || value.Trim().EndsWith("}"));
            return !(value.StartsWith("*****") || value.StartsWith("無し"));
        }

        public void WriteValues(SqlConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandText = CreateSQL();
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
        }

        public string SafeSQL(string input)
        {
            return input.Replace("'", "''");
        }
    }
}
