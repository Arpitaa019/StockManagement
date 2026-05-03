using StockManagement.Core;
using StockManagement.Core;
using StockManagement.Interface;
using System.Collections.Generic;
using System.Linq;

namespace StockManagement.Repository
{
    public class LineRepository : ILineRepository
    {
        // Generate static sample data: at least 20 lines with 100 spools total (5 spools per line)
        private static readonly List<Line> _lines = GenerateSampleLines();

        public IEnumerable<Line> GetAllLines() => _lines;

        public Line? GetLineById(int id) => _lines.FirstOrDefault(l => l.LineId == id);

        private static List<Line> GenerateSampleLines()
        {
            // Construct sample lines, spools and components using identifiers inspired by the provided image
            var lines = new List<Line>();
            int compId = 1000;
            int jointId = 5000;

            // Example lines taken from the screenshot (shortened versions)
            var sample = new[]
            {
                new {
                    LineId = 12,
                    Name = "12.00-P-OIG-4513-B1A-IHC",
                    Spools = new[] {
                        new { SpoolNumber = "12.00-P-OIG-4513", Uids = new[] {"U188","U186","U184","U180","U178","U176"} },
                        new { SpoolNumber = "12.00-P-OIG-4514", Uids = new[] {"U176","U174","U172"} }
                    }
                },
                new {
                    LineId = 18,
                    Name = "18.00-FL-OIG-4301-A1A-IHC",
                    Spools = new[] {
                        new { SpoolNumber = "18.00-FL-OIG-4301", Uids = new[] {"U301","U302"} },
                        new { SpoolNumber = "18.00-FL-OIG-4302", Uids = new string[] {} }
                    }
                },
                new {
                    LineId = 14,
                    Name = "14.00-P-OIG-4306-A1A-IHC",
                    Spools = new[] {
                        new { SpoolNumber = "14.00-P-OIG-4306", Uids = new[] {"U210","U211","U212"} }
                    }
                },
                new {
                    LineId = 6,
                    Name = "06.00-WF-OIG-7701-A33Y-C",
                    Spools = new[] {
                        new { SpoolNumber = "06.00-WF-OIG-7701", Uids = new[] {"U401"} },
                        new { SpoolNumber = "06.00-WF-OIG-7702", Uids = new string[] {} }
                    }
                },
                new {
                    LineId = 30,
                    Name = "30.00-P-OIG-2503-D23A-IHC",
                    Spools = new[] {
                        new { SpoolNumber = "30.00-P-OIG-2503", Uids = new[] {"U601","U602","U603","U604"} }
                    }
                },
                new {
                    LineId = 8,
                    Name = "08.00-P-OIG-2303-D5A-IHC",
                    Spools = new[] {
                        new { SpoolNumber = "08.00-P-OIG-2303", Uids = new[] {"U701","U702"} }
                    }
                },
                new {
                    LineId = 10,
                    Name = "10.00-P-OIG-5412-A1A-IHC",
                    Spools = new[] {
                        new { SpoolNumber = "10.00-P-OIG-5412", Uids = new[] {"U801","U802","U803"} }
                    }
                },
                new {
                    LineId = 20,
                    Name = "20.00-P-OIG-4716-B1A-IHC",
                    Spools = new[] {
                        new { SpoolNumber = "20.00-P-OIG-4716", Uids = new[] {"U901","U902","U903","U904"} }
                    }
                }
            };

            int lid = 1;
            foreach (var l in sample)
            {
                var line = new Line { LineId = lid++, Name = l.Name, Description = "Sample line" , Spools = new List<Spool>() };
                foreach (var s in l.Spools)
                {
                    var spool = new Spool { SpoolId = ++compId, SpoolNumber = s.SpoolNumber, Description = "", Components = new List<Component>(), Joints = new List<Joint>() };

                    // add components from UIDs
                    foreach (var uid in s.Uids)
                    {
                        var c = new Component { ComponentId = ++compId, SpoolId = spool.SpoolId, ItemCodeNo = uid, PartNumber = $"PN-{uid}", Description = $"UID {uid}" , Quantity = 1, UnitOfMeasure = "PCS" };
                        spool.Components.Add(c);
                    }

                    // add joints (pair consecutive components)
                    for (int i = 0; i + 1 < spool.Components.Count; i++)
                    {
                        var j = new Joint { JointId = ++jointId, SpoolId = spool.SpoolId, JointNumber = (i+1).ToString(), Part1ComponentId = spool.Components[i].ComponentId, Part2ComponentId = spool.Components[i+1].ComponentId, Description = "" };
                        spool.Joints.Add(j);
                    }

                    line.Spools.Add(spool);
                }
                lines.Add(line);
            }

            return lines;
        }
    }
}
