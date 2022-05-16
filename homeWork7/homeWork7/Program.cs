using homeWork7;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TemplateEngine.Docx;

List<CustomDrive> drives = new List<CustomDrive>();
drives.Add(new CustomDrive("C", CDriveType.Fixed, FileSystemType.NTFS, 487727, 116620, "8412-22EB"));
drives.Add(new CustomDrive("D", CDriveType.Fixed, FileSystemType.NTFS, 953751, 520734, "0AFD-4544"));
CustomReport.DrivesReport(drives);
Console.WriteLine("Выполнено");