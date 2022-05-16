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
        /*List<IContentItem> items = new List<IContentItem>();
        foreach(var data_item in data)
        {
            items.Add(new FieldContent("Drive Name", data_item.Name));
            items.Add(new FieldContent("Drive Type", data_item.Type.ToString()));
            items.Add(new FieldContent("Drive Filesystem", data_item.Filesystem.ToString()));
            items.Add(new FieldContent("Drive TotalMemory", data_item.TotalMemory.ToString()));
            items.Add(new FieldContent("Drive UsedMemory", data_item.UsedMemory.ToString()));
            items.Add(new FieldContent("Drive FreeMemory", data_item.FreeMemory.ToString()));
            items.Add(new FieldContent("Drive PercentOfFreeMemory", data_item.PercentOfFreeMemory.ToString()));
            items.Add(new FieldContent("Drive VolumeNumber", data_item.VolumeNumber));
            break;
        }

        TableRowContent[] jj = new TableRowContent[items.Count];
        for(int i = 0; i < items.Count; i++)
        {
            jj[i] = new TableRowContent(items[i]);
        }*/

        //var t = new TableContent("...", jj);
        //var valuesToFill = new Content(t);

        var drive_one = data[0];
        var drive_two = data[1];
        var valuesToFill = new Content(
            new TableContent("MyTable")
                .AddRow(
                    new FieldContent("Name", drive_one.Name),
                    new FieldContent("Type", drive_one.Type.ToString()),
                    new FieldContent("Filesystem", drive_one.Filesystem.ToString()),
                    new FieldContent("TotalMemory", drive_one.TotalMemory.ToString()),
                    new FieldContent("UsedMemory", drive_one.UsedMemory.ToString()),
                    new FieldContent("FreeMemory", drive_one.FreeMemory.ToString()),
                    new FieldContent("PercentOfFreeMemory", drive_one.PercentOfFreeMemory.ToString()),
                    new FieldContent("VolumeNumber", drive_one.VolumeNumber))
                .AddRow(
                    new FieldContent("Name", drive_two.Name),
                    new FieldContent("Type", drive_two.Type.ToString()),
                    new FieldContent("Filesystem", drive_two.Filesystem.ToString()),
                    new FieldContent("TotalMemory", drive_two.TotalMemory.ToString()),
                    new FieldContent("UsedMemory", drive_two.UsedMemory.ToString()),
                    new FieldContent("FreeMemory", drive_two.FreeMemory.ToString()),
                    new FieldContent("PercentOfFreeMemory", drive_two.PercentOfFreeMemory.ToString()),
                    new FieldContent("VolumeNumber", drive_two.VolumeNumber)));        

        using (var outputDocument = new TemplateProcessor(output).SetRemoveContentControls(true))
        {            
            outputDocument.FillContent(valuesToFill);
            outputDocument.SaveChanges();
        }
    }
}
