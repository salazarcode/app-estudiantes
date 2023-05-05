﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
	public interface IRepository<TEntity> where TEntity : class
	{
		TEntity GetById(int id);
		IEnumerable<TEntity> GetAll();
		void Add(TEntity entity);
		void Update(TEntity entity);
		void Remove(TEntity entity);
	}
}
