using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Seedwork;

/// <summary>
/// Eric Evans
/// </summary>
public abstract class Entity : object
{
	protected Entity() : base()
	{
	}

	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
	public int Id { get; init; }
}
