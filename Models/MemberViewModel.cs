using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorServerApp.Models
{
    [Serializable]
    public class MemberViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage ="Nazwa uzytkownika nie moze byc dłuższa niż 12 znaków")]
        [MinLength(3, ErrorMessage ="Nazwa uzytkownika musi zawierać przynajmniej 3 znaki")]
        public string MemberName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Niepoprawny adres email")]
        public string Email { get; set; }
        [Required]
        //[Range(18, 100, ErrorMessage ="Wiek musi być w przedziale od 18 do 100")]
        public int Age { get; set; }

        public string MemberCnt { get; set; }

        public DateTime JoiningDate { get; set; }
    }
}
