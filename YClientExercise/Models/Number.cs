using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace YClientExercise.Models
{
    public class Number
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public double Value { get; set; }
    }
}