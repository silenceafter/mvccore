using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateEngine.Docx;

namespace homeWork7;

public static class CustomReport
{
    public static void DrivesReport(List<CustomDrive> data, string output = "")
    {
        if (data.Count == 0)
            return;

        if (string.IsNullOrWhiteSpace(output))
            output = Path.Combine(Directory.GetCurrentDirectory(), "CustomReport.docx");

        if (File.Exists(output))
            File.Delete(output);

        File.Copy("ReportTemplate.docx", output);
        //
        var tableContent = new TableContent("MyTable");
        List<IContentItem> items = new List<IContentItem>();
        for(int i = 0; i < 2; i++)
        {
            tableContent.AddRow(
                new FieldContent("Name", data[i].Name),
                new FieldContent("Type", data[i].Type.ToString()),
                new FieldContent("Filesystem", data[i].Filesystem.ToString()),
                new FieldContent("TotalMemory", data[i].TotalMemory.ToString()),
                new FieldContent("UsedMemory", data[i].UsedMemory.ToString()),
                new FieldContent("FreeMemory", data[i].FreeMemory.ToString()),
                new FieldContent("PercentOfFreeMemory", data[i].PercentOfFreeMemory.ToString()),
                new FieldContent("VolumeNumber", data[i].VolumeNumber));
        }

        var valuesToFill = new Content(tableContent);
        using (var outputDocument = new TemplateProcessor(output).SetRemoveContentControls(true))
        {            
            outputDocument.FillContent(valuesToFill);
            outputDocument.SaveChanges();
        }
    }
}
