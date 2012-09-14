using System;
using System.Collections.Generic;

namespace Api.Implementations
{
	public interface IHandlerMapper
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T">Request DTO</typeparam>
		/// <typeparam name="TU">Response DTO</typeparam>		
		void Register(Type dtoType, Func<object, object> handler);

	
		object Publish<T>(T dto);
	}

	public class HandlerMapper : IHandlerMapper
	{
		private readonly Dictionary<string, Func<object, object>> _handlers;
 
		public HandlerMapper()
		{
			_handlers = new Dictionary<string, Func<object, object>>();			
		}
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T">Request DTO</typeparam>
		/// <typeparam name="TU">Response DTO</typeparam>		
		public void  Register(Type dtoType, Func<object, object> handler)
		{
	
		var handlerKey = GetKey(dtoType);

			_handlers.Add(handlerKey, o => handler(o));
		}

		public object Publish<T>(T dto)
		{
			var handlerKey = GetKey(default(T));
			if (_handlers.ContainsKey(handlerKey))
			{
				var func = _handlers[handlerKey];
				return func(dto);
			}
			throw new InvalidOperationException();
		}

		private static string GetKey(object o)
		{
			return o.GetType().FullName;
		}
	}
}
