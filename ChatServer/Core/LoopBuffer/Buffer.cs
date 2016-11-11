namespace ChatServer.Core.LoopBuffer {
	public class Buffer {
		private readonly string[] _buffer;
		private readonly uint _lenght;

		private uint currentItem = 0;

		public Buffer(uint lenght) {
			_buffer = new string[lenght];
			_lenght = lenght;
		}

		public void Add(string msg) {
			if (currentItem > _lenght-1) {
				currentItem = 0;
			}
			_buffer[currentItem] = msg;
			currentItem++;
		}

		public string[] getBuffer() {
			return _buffer;
		}
	}
}