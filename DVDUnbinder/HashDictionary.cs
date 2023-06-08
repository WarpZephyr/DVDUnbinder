using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DVDUnbinder
{
    public static class HashDictionary
    {
        public static Dictionary<uint, string> ReadDictionary(string path)
        {
            var dict = new Dictionary<uint, string>();

            if (File.Exists(path))
            {
                foreach (string line in File.ReadAllLines(path))
                {
                    if (line.Trim() != "")
                    {
                        Add(dict, line);
                    }
                }
            }

            return dict;
        }

        private static void Add(Dictionary<uint, string> dict, string line)
        {
            bool found;
            do
            {
                found = false;
                foreach (string k in Paths.Keys)
                {
                    if (line.Contains(k))
                    {
                        found = true;
                        line = line.Replace(k, Paths[k]);
                    }
                }
            }
            while (found);

            do
            {
                found = false;
                foreach (string k in Aliases.Keys)
                {
                    if (line.StartsWith(k))
                    {
                        found = true;
                        line = line.Replace(k, Aliases[k]);
                    }
                }
            }
            while (found);

            line = line.Replace('/', '\\');
            while (line.StartsWith(".\\"))
                line = line.Substring(2);

            void langAdd(string l)
            {
                if (l.Contains("$(Lang)"))
                {
                    foreach (string lang in Langs)
                        langAdd(l.Replace("$(Lang)", lang));
                }
                else
                {
                    dict[ComputeHash(l)] = l;
                    dict[ComputeHash(l + ".dcx")] = l + ".dcx";
                }
            }

            MatchCollection formats = Regex.Matches(line, @"\{(\d)\:D(\d)\}");
            if (formats.Count == 0)
            {
                langAdd(line);
            }
            else
            {
                var powers = new List<int>();
                foreach (Match format in formats)
                {
                    int index = int.Parse(format.Groups[1].Value);
                    int power = int.Parse(format.Groups[2].Value);
                    while (powers.Count <= index)
                        powers.Add(0);
                    powers[index] = Math.Min(power, powers[index] == 0 ? int.MaxValue : powers[index]);
                }

                if (powers.Sum() <= 6)
                {
                    var values = new object[powers.Count];
                    void blast(int index)
                    {
                        for (int i = 0; i < Math.Pow(10, powers[index]); i++)
                        {
                            values[index] = i;
                            if (index == powers.Count - 1)
                            {
                                string l = string.Format(line, values);
                                langAdd(l);
                            }
                            else
                            {
                                blast(index + 1);
                            }
                        }
                    }
                    blast(0);
                }
            }
        }

        private static uint ComputeHash(string path)
        {
            string hashable = path.Trim().Replace('\\', '/').ToLowerInvariant();
            if (!hashable.StartsWith("/"))
                hashable = '/' + hashable;
            return hashable.Aggregate(0u, (i, c) => i * 37 + c);
        }

        private static List<string> Langs = new List<string>()
        {
            "EN",
            "FR",
            "GE",
            "IT",
            "JP",
            "SP",
        };

        private static Dictionary<string, string> Paths = new Dictionary<string, string>()
        {
            //["$(Lang)"] = @"jp",
            ["$(VoiceLang)"] = @"jp",
            ["$(Pub)"] = @"UBI",
            ["$(TrialTitleRes)"] = @"Trial_Title",
            ["$(RatingSystem)"] = @"ESRB",
            ["$(Data)"] = @"game_bind:",
            ["$(Common)"] = @"$(Data)",
            ["$(FontData)"] = @"$(Data)\font",
            ["$(ModelData)"] = @"$(Data)\model",
            ["$(MapModelData)"] = @"$(ModelData)\map",
            ["$(ObjModelData)"] = @"$(ModelData)\obj",
            ["$(EneModelData)"] = @"$(ModelData)\ene",
            ["$(PartsData)"] = @"$(Common)\Param\AcParts.bin",
            ["$(MissionData)"] = @"$(Common)\Lang\$(Lang)\Param\MissionInfo.bin",
            ["$(AIResource)"] = @"$(Data)\AiResource",
            ["$(AIParam_mission)"] = @"$(Data)\AiResource\Mission",
            ["$(Viewer)"] = @"$(Common)\Viewer",
            ["$(Effect)"] = @"$(Data)\Effect",
            ["$(MapViewerDefaultMap)"] = @"$(Data)\mission\mission_0000.xml",
            ["$(CoOpDefaultMapID)"] = @"410",
            ["$(VersusDefaultMap)"] = @"$(Data)\mission\BattleFeild_5000.xml",
            ["$(TutorialMap)"] = @"$(MapModelData)\m710\m710.msb",
            ["$(AcTestMap)"] = @"$(MapModelData)\m720\m720.msb",
            ["$(EventStdLoadScript)"] = @"$(Common)\Event\Include\inc.lua",
            ["$(AIStdLoadScript)"] = @"$(AIScript)\include\include.lua",
            ["$(AIScript)"] = @"aiscript:",
            ["$(MissionEventScript)"] = @"$(Common)\Event\Mission",
            ["$(ObjectEventScript)"] = @"$(Common)\Event\Mission",
            ["$(NavGraph)"] = @"$(Data)\AiResource\NavGraph",
            ["$(BriefingCAP)"] = @"$(Data)\cap\briefing",
            ["$(MissionCAP)"] = @"$(Data)\cap\mission",
            ["$(MissionDefaultCAP)"] = @"$(MissionCAP)\MissionDefault.cap",
            ["$(TutorialCAP)"] = @"$(Data)\cap\Tutorial",
            ["$(Movie)"] = @"movie:\jp",
            ["$(Bind)"] = @"$(Data)\bind\$(Lang)",
            ["$(Shader)"] = @"$(Data)\Shader",
            ["$(LocalizeTarget)"] = @"$(Data)\Lang\$(Lang)",
            ["$(MenuTextDir)"] = @"$(LocalizeTarget)\Text\Menu",
            ["$(TutorialMsg)"] = @"$(LocalizeTarget)\Text\Tutorial\Tutorial.fmg",
            ["$(MissionMsgDir)"] = @"$(LocalizeTarget)\Text\Mission",
            ["$(VersusMsgDir)"] = @"$(LocalizeTarget)\Text\Versus",
            ["$(MissionDefMsgFile)"] = @"MissionDefault",
            ["$(MissionDefaultMsg)"] = @"$(LocalizeTarget)\Text\Mission\MissionDefault.fmg",
            ["$(KeyGuideDir)"] = @"$(LocalizeTarget)\System",
            ["$(Ac4MenuResource)"] = @"$(Data)\Lang\JP\menu\Ac4",
            ["$(MenuResource)"] = @"$(Data)\Lang\$(Lang)\menu",
            ["$(BriefingResource)"] = @"$(LocalizeTarget)\Briefing",
            ["$(PartsNameFmg)"] = @"$(LocalizeTarget)\Text\PartsName_$(Lang).fmg",
            ["$(PartsExplainFmg)"] = @"$(LocalizeTarget)\Text\PartsExplain_$(Lang).fmg",
            ["$(BindEmblemTexBase)"] = @"Lang\jp",
            ["$(NowloadTexBase)"] = @"$(Data)\Lang\$(Lang)\nowload\tex",
            ["$(EmblemPreparedRoot)"] = @"$(Data)\Lang\jp\model\image\im0000\tex",
            ["$(MissionSaveData)"] = @"/app_home/N:\ACV\data\game\common\msave",
            ["$(AutorunTest)"] = @"/app_home/N:\ACV\data\game\common\test\AutoRun",
            ["$(RegionData)"] = @"$(Data)\Region\$(Region)",
        };

        private static Dictionary<string, string> Aliases = new Dictionary<string, string>()
        {
            ["acv_patch:"] = ".",
            ["aicustom:"] = "game:/airesource/customai",
            ["aiscript:"] = "game:/airesource/script",
            ["bind:"] = "game:/bind",
            ["content_info:"] = ".",
            ["custommap:"] = "game_bind:/custommap",
            ["db_aicustom:"] = ".",
            ["db_asm_common:"] = ".",
            ["db_asm_savedata:"] = ".",
            ["db_asm_versus:"] = ".",
            ["db_layoutfile_savedata:"] = ".",
            ["db_missionsavedata:"] = ".",
            ["db_opfile_savedata:"] = ".",
            ["db_opfile_testdata:"] = ".",
            ["db_statistics_save:"] = ".",
            ["dlc_ai_unlock:"] = ".",
            ["dlc_game:"] = "game:",
            ["dlc_image:"] = "image:",
            ["dlc_model_ac:"] = "model_ac:",
            ["dlc_model_ene:"] = "model_ene:",
            ["dlc_model_menu:"] = "model_menu:",
            ["dlc_param:"] = "param",
            ["dlc_sfx:"] = "sfx:",
            ["dlc_sound:"] = "sound:",
            ["dummyserverdata:"] = ".",
            ["enescript:"] = "game:/script",
            ["game:"] = ".",
            ["game_bind:"] = ".",
            ["game_debug:"] = ".",
            ["game_test:"] = ".",
            ["image:"] = "game_bind:/image",
            ["install:"] = ".",
            ["mission_bnd:"] = "game_bind:/bind/mission",
            ["model_ac:"] = "game_bind:/model/ac",
            ["model_cam:"] = "game_bind:/model/cam",
            ["model_decal:"] = "game_bind:/model/decal",
            ["model_ene:"] = "game_bind:/model/ene",
            ["model_image:"] = "game_bind:/model/image",
            ["model_map_tex:"] = "game_bind:/model/map",
            ["model_menu:"] = "game_bind:/model/menu",
            ["model_obj:"] = "game_bind:/model/obj",
            ["model_poly:"] = "game_bind:/model/poly",
            ["movie:"] = "game:/movie",
            ["paramcalc:"] = "game:/param",
            ["saveicon:"] = "game_bind:/saveicon",
            ["scene:"] = "game:/scene",
            ["sfx:"] = "game_bind:/",
            ["shader:"] = "game_bind:/shader",
            ["sound:"] = "game_bind:/sound",
            ["sound_stream:"] = ".",
            ["system:"] = ".",
            ["tae:"] = "game_bind:/tae",
            ["temp:"] = ".",
            ["viewer:"] = ".",
        };
    }
}
