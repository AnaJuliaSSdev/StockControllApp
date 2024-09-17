    using Models.DTO.BatchDto;
    using Models.Models;

    namespace Models.DTO.InventoryDto;

    public class ListInventoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<ListBatchInventoryDto> Batches { get; set; } = [];
    }
