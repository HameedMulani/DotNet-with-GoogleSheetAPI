using Personal_Information.Model;

namespace Personal_Information.Dao
{
    public static class ItemsMapper
    {
        // Mapping from Google Sheets data to Item model
        public static List<Item> MapFromRangeData(IList<IList<object>> values)
        {
            var items = new List<Item>();
            int count = 0;
            foreach (var value in values)
            {


                Item item = new()
                {
                    Name = value[0]?.ToString(),
                    DateOfBirth = DateTime.TryParse(value[1]?.ToString(), out DateTime dob) ? dob : DateTime.MinValue,
                    ResidentialAddress = value[2]?.ToString(),
                    PermanentAddress = value[3]?.ToString(),
                    MobileNumber = value[4]?.ToString(),
                    EmailAddress = value[5]?.ToString(),
                    MaritalStatus = value[6]?.ToString(),
                    Gender = value[7]?.ToString(),
                    Occupation = value[8]?.ToString(),
                    AadharCardNumber = value[9]?.ToString(),
                    PANNumber = value[10]?.ToString()
                };

                items.Add(item);
            }

            return items;
        }

        // Mapping from Item model to Google Sheets data format
        public static IList<IList<object>> MapToRangeData(Item item)
        {
            var objectList = new List<object>()
            {
                item.Name,
                item.DateOfBirth.ToString("yyyy-MM-dd"),
                item.ResidentialAddress,
                item.PermanentAddress,
                item.MobileNumber,
                item.EmailAddress,
                item.MaritalStatus,
                item.Gender,
                item.Occupation,
                item.AadharCardNumber,
                item.PANNumber
            };

            var rangeData = new List<IList<object>> { objectList };
            return rangeData;
        }
    }
}
