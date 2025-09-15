using System.Collections.Generic;

namespace WorkSync.Domain.Providers.Office;

public interface IOfficeProvider
{
    string ExportAndUploadExcel<T>(IList<T> data, IList<ExcelFormat> formats, string fileName);
}
