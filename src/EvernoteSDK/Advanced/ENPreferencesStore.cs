using Evernote.EDAM.Type;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml;

namespace EvernoteSDK
{
	namespace Advanced
	{
		public class ENPreferencesStore
		{
			private string Pathname {get; set;}
			private Dictionary<string, object> Store {get; set;}

			private static object PathnameForStoreFilename(string filename)
			{
				FileVersionInfo vi = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
				var companyKey = vi.CompanyName;
				var productKey = vi.ProductName;
				if (companyKey.Length == 0)
				{
					companyKey = productKey;
				}
				return string.Format("{0}\\{1}\\{2}\\{3}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), companyKey, productKey, filename);
			}

			public ENPreferencesStore(string filename)
			{
				Pathname = PathnameForStoreFilename(filename).ToString();
				Store = new Dictionary<string, object>();
				Load();
			}

            private T ObjectForKey<T>(string key)
            {
                object value = null;
                Store.TryGetValue(key, out value);
                return (T)value;
            }

            private void SetObject(object objectToStore, string key)
            {
                if (objectToStore != null)
                {
                    Store[key] = objectToStore;
                }
                else
                {
                    Store.Remove(key);
                }
                Save();
            }

            public bool? BoolForKey(string key)
			{
				return ObjectForKey<bool?>(key);
			}

			public void SetBool(bool? objectToStore, string key)
			{
				SetObject(objectToStore, key);
			}

			public string StringForKey(string key)
			{
				return ObjectForKey<string>(key);
			}

			public void SetString(string objectToStore, string key)
			{
				SetObject(objectToStore, key);
			}

			public User UserForKey(string key)
            {
				return ObjectForKey<User>(key);
			}

			public void SetUser(User objectToStore, string key)
            {
				SetObject(objectToStore, key);
			}

			public LinkedNotebook LinkedNotebookForKey(string key)
			{
				return ObjectForKey<LinkedNotebook>(key); ;
			}

			public void SetLinkedNotebook(LinkedNotebook objectToStore, string key)
			{
				SetObject(objectToStore, key);
			}

			public SharedNotebook SharedNotebookForKey(string key)
			{
				return ObjectForKey<SharedNotebook>(key); ;
			}

			public void SetSharedNotebook(SharedNotebook objectToStore, string key)
			{
				SetObject(objectToStore, key);
			}
			public ENCredentialStore ENCredentialStoreForKey(string key)
			{
				return ObjectForKey<ENCredentialStore>(key);
			}

			public void SetENCredentialStore(ENCredentialStore objectToStore, string key)
			{
				SetObject(objectToStore, key);
			}

			private void Save()
            {
                string dir = Path.GetDirectoryName(Pathname);
                if (!(Directory.Exists(dir)))
                {
                    Directory.CreateDirectory(dir);
                }

				ENPreferencesStoreXmlStorage.Save(Pathname, Store);
            }

			public void RemoveAllObjects()
			{
				Store.Clear();
				Save();
			}

            private void Load()
            {
                AppDomain currentDomain = AppDomain.CurrentDomain;

                currentDomain.AssemblyResolve += MyResolveEventHandler;

                if (File.Exists(Pathname))
                {
					Store = ENPreferencesStoreXmlStorage.Load(Pathname);
				}
            }

            private Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
            {
                Assembly[] ayAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (Assembly item in ayAssemblies)
                {
                    if (item.FullName == args.Name)
                    {
                        return item;
                    }
                }

                return null;
            }

		}
	}

}