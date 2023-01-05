namespace WebMVCaPPLICATION.infrastructure
{
    public static class Event

    {
        public static string GetAllTypes(string baseUrl)
        {
            return $"{baseUrl}/eventtypes";
        }
        public static string GetAllOrganizers(string baseUrl)
        {
            return $"{baseUrl}/organizers";
        }
        public static string GetAllItems(string baseUrl, int page, int take)
        {
            return $"{baseUrl}/items?pageIndex={page}&pageSize={take}";
        }
    }
}
