using System;
namespace ParseJSON.DataClasses
{
    public class SkillEn : Skill
    {

        public SkillEn(string values, int rowindex):base(values, rowindex)
        {
        }

        protected override void ParseString(string values, int rowindex)
        {
            var fields = values.Split(',');
            SkillJD = rowindex;

            for (int i = 0; i < fields.Length; i++)
            {
                string stringval = fields[i];
                int intval;
                int.TryParse(fields[i], out intval);
                switch (i)
                {
                    case 0:
                        //SkillEn/Jp
                        SkillEn = stringval;
                        break;
                    case 1:
                        //EffectEn/Jp
                        EffectEn = stringval;
                        break;
                    case 2:
                        //GroupID
                        GroupID = intval;
                        break;
                    case 3:
                        //LevelCap
                        LevelCap = intval;
                        break;
                    case 4:
                        //MaxCD
                        MaxCD = intval;
                        break;
                    case 6:
                        //Special1
                        Special1 = intval;
                        break;
                    case 7:
                        //Special2
                        Special2 = intval;
                        break;
                    case 8:
                        //special3
                        Special3 = intval;
                        break;
                    case 9:
                        //special4
                        Special4 = intval;
                        break;
                    case 10:
                        //Special5
                        Special5 = intval;
                        break;
                    case 11:
                        //Special6
                        Special6 = intval;
                        break;
                    case 12:
                        //Special7
                        Special7 = intval;
                        break;
                    case 13:
                        //special8
                        Special8 = intval;
                        break;
                    default:
                        //ignore these values
                        break;
                }
            }
        }

        protected override string CreateSQL()
        {
            return $"update skill set SkillEN='{SafeSQL(SkillEn)}', " +
                $"                    EffectEn='{SafeSQL(EffectEn)}', " +
                $"                    LevelCap={LevelCap}, MaxCD={MaxCD}, " +
                $"                    Special1={Special1}, Special2={Special2}, " +
                $"                    Special3={Special3}, Special4={Special4}," +
                $"                    Special5={Special5}, Special6={Special6}," +
                $"                    Special7={Special7}, Special8={Special8} Where skillid = (select top 1 skillid from skill where GroupID={GroupID} and SkillJD={SkillJD} order by skillid)";
            
        }
    }
}
