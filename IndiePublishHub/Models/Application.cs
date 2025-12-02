using System.ComponentModel.DataAnnotations;

namespace IndiePublishHub.Models
{
    public class Application
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя обязательно")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Неверный формат email")]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Неверный формат телефона")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Название компании обязательно")]
        [StringLength(200)]
        public string Company { get; set; } = string.Empty;

        [Required(ErrorMessage = "Описание проекта обязательно")]
        [StringLength(1000)]
        public string ProjectDescription { get; set; } = string.Empty;

        [Range(1, 10, ErrorMessage = "Выберите количество игр")]
        public int GamesCount { get; set; } = 1;

        public string? PreferredStores { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsProcessed { get; set; } = false;
    }
}