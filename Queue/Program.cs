using System;

namespace Queue
{
	public class Queue
	{
		public int Count { get; private set; }
		public int NumberQueue { get; private set; }
		private Element _first;
		private Element _last;

		public Queue()
		{
			Count = 3;
			NumberQueue = 0;
		}
		public Queue(int count)
		{
			Count = count;
		}

		public void Enqueue(int value)
		{
			//1.1	Enqueue – данный метод должен получать на вход целое число и помещать его в конец очереди.
			if (NumberQueue >= Count)
			{
				throw new IndexOutOfRangeException();
			}
			else
			{
				if (NumberQueue == 0)
				{
					_first = new Element
					{
						Value = value,
						Previous = null
					};
					_last = _first;
					NumberQueue++;
					return;
				}
				var newEnd = new Element
				{
					Value = value,
					Previous = null
				};
				_last.Previous = newEnd;
				_last = newEnd;
				NumberQueue++;
			}
		}

		public int Dequeue()
		{
			var value = _first.Value;
			_first = _first.Previous;
			NumberQueue--;
			return value;
		}

		public int Peek()
		{
			return _first.Value;
		}

	}

	public class Element
	{
		public int Value { get; set; }

		public Element Previous { get; set; }
	}

	class Stack
	{
		private Element _last;

		public int Count { get; private set; }
		public Stack()
		{
			Count = 0;
		}

		public void Push(int value)
		{
			AddEnd(value);
		}
		public void AddEnd(int value)
		{
			if (Count == 0)
			{
				AddFirst(value);
				return;
			}
			var newEnd = new Element
			{
				Value = value,
				Previous = _last
			};
			_last = newEnd;
			Count++;
		}
		private void AddFirst(int value)
		{
			_last = new Element
			{
				Value = value,
				Previous = null
			};
			Count++;

		}

		public int Pop()
		{
			var value = _last.Value;
			_last = _last.Previous;
			Count--;
			return value;
		}

		public int Peek()
		{
			return _last.Value;
		}
	}
	public class Program
	{
		static void Main(string[] args)
		{
			var stack = new Stack();
			var queue = new Queue();

			var numbers = new int[] { 5, 10, 15 };

			for (var i = 0; i < numbers.Length; i++)
			{
				queue.Enqueue(numbers[i]);
				stack.Push(numbers[i]);
			}
			while (queue.NumberQueue > 0)
			{
				Console.WriteLine($"Получил значение {queue.Peek()}");
				Console.WriteLine($"Удалил значение {queue.Dequeue()}");
			}
			Console.WriteLine("\nРабота со Стеком");
			while (stack.Count > 0)
			{
				Console.WriteLine($"Получил значение {stack.Peek()}");
				Console.WriteLine($"Удалил значение {stack.Pop()}");

			}

		}
	}
}
