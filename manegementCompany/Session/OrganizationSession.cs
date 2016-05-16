using System;

namespace web.Session
{
	public static class OrganizationSession
	{
		public static int id { set; get; } = -1;

		public static bool isSession() {
			return id != -1;
		}

		public static void newSession(int session) {
			id = session;
		}

		public static void removeSession () {
			id = -1;
		}

		public static int session() {
			return id;
		}
	}
}

