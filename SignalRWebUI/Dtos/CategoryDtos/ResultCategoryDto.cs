namespace SignalRWebUI.Dtos.CategoryDtos
{
	public class ResultCategoryDto
	{
		//proportileri eşleştirmem için olmazsa olmaz dto ları yazmamız gerekmekte
		//ilk yazdığımız dto lar sadece api için çalışıyordu ui için de ayrı viewmodellerimize dto larımıza ihtiyaç var
		//uı için mde tek tek yazmamız gerekmekte olmazsa olamaz json dan gelen proportiler için şart
		//dto yu kullanamaz mıyım hayır çünkü 5 katman ayrrı bir projeden geliyor ama biz bu katmanda sadece UI ı geliştiriyoruz
		//UI ile Api nin port numaraları aynı değil çünkü
		//webUI ile api projeleri aynı değil burada sadece apiyi tüketiyoruz
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public bool CategoryStatus { get; set; }
	}
}
