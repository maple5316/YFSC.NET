using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;

namespace YaleFigureSkatingClub.Entities
{
	public class UserMapping : ClassMap<User>
	{
		public UserMapping ()
		{
			Table ("Users");
			LazyLoad();
			Id (x => x.Username).Column ("Username").Length(255);
			Map (x => x.Password).Column("Password").Length (3000);
			Map (x => x.Email).Column ("Email");
			HasMany (x => x.Roles)
				.KeyColumn("Username")
				.Inverse()
				.Cascade.All ();
			HasMany (x => x.Registrations)
				.KeyColumn ("Username")
				.Inverse()
				.Cascade.All();
		}
	}
}

