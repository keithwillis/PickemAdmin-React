using System;
namespace ParseJSON.DataClasses
{
    public class SkillJP : Skill
    {
        public SkillJP(string values, int rowindex) : base(values, rowindex)
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
                        SkillJp = stringval;
                        break;
                    case 1:
                        //EffectEn/Jp
                        EffectJp = stringval;
                        break;
                    case 2:
                        //GroupID
                        GroupIDJp = intval;
                        break;
                    case 3:
                        //LevelCap
                        LevelCapJp = intval;
                        break;
                    case 4:
                        //MaxCD
                        MaxCDJp = intval;
                        break;
                    case 6:
                        //Special1
                        Special1Jp = intval;
                        break;
                    case 7:
                        //Special2
                        Special2Jp = intval;
                        break;
                    case 8:
                        //special3
                        Special3Jp = intval;
                        break;
                    case 9:
                        //special4
                        Special4Jp = intval;
                        break;
                    case 10:
                        //Special5
                        Special5Jp = intval;
                        break;
                    case 11:
                        //Special6
                        Special6Jp = intval;
                        break;
                    case 12:
                        //Special7
                        Special7Jp = intval;
                        break;
                    case 13:
                        //special8
                        Special8Jp = intval;
                        break;
                    default:
                        //ignore these values
                        break;
                }
            }
        }

        protected override string CreateSQL()
        {
            return $"update skill set SkillJp='{SafeSQL(SkillJp)}', " +
                $"                    EffectJp='{SafeSQL(EffectJp)}', " +
                $"                    LevelCapJp={LevelCapJp}, MaxCDJp={MaxCDJp}, " +
                $"                    Special1Jp={Special1Jp}, Special2Jp={Special2Jp}, " +
                $"                    Special3Jp={Special3Jp}, Special4Jp={Special4Jp}," +
                $"                    Special5Jp={Special5Jp}, Special6Jp={Special6Jp}," +
                $"                    Special7Jp={Special7Jp}, Special8Jp={Special8Jp} Where skillid = (select top 1 skillid from skill where GroupIDJp={GroupIDJp} and SkillJD={SkillJD} order by skillid)";

        }


    }

}
