using Evernote.EDAM.Type;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EvernoteSDK
{
    internal static class ENPreferencesStoreXmlStorage
    {
		public static void Save(string filename, Dictionary<string, object> data)
		{
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Indent = true;
			settings.IndentChars = "    ";
			settings.NewLineChars = "\n";
			using (XmlWriter writer = XmlWriter.Create(filename, settings))
			{
				Save(writer, data);
			}
		}

		public static void Save(XmlWriter writer, Dictionary<string, object> data)
		{
			writer.WriteStartDocument();
			writer.WriteStartElement("EvernotePreferences");

			if (data == null)
            {
				writer.WriteAttributeString("null", "true");
				return;
            }

			foreach (KeyValuePair<string, object> pair in data)
			{
				writer.WriteStartElement(pair.Key);
				Save(writer, pair.Value);
				writer.WriteEndElement();
			}

			writer.WriteEndElement();
			writer.WriteEndDocument();
		}

		private static void Save(XmlWriter writer, object value)
		{
			if (value is bool boolValue)
			{
				writer.WriteAttributeString("type", "bool");
				writer.WriteString(XmlConvert.ToString(boolValue));
			}
			else if (value is string stringValue)
			{
				writer.WriteAttributeString("type", "string");
				writer.WriteString(stringValue);
			}
			else
			if (value is User user)
			{
				writer.WriteAttributeString("type", "user");
				SaveValue(writer, user);
			}
			else
			if (value is LinkedNotebook ln)
			{
				writer.WriteAttributeString("type", "linked-notebook");
				SaveValue(writer, ln);
			}
			else
			if (value is SharedNotebook sn)
			{
				writer.WriteAttributeString("type", "shared-notebook");
				SaveValue(writer, sn);
			}
			else
			if (value is ENCredentialStore cs)
			{
				writer.WriteAttributeString("type", "credential-store");
				SaveValue(writer, cs);
			}
			else if (value == null)
			{
				writer.WriteAttributeString("type", "null");
			}
			else
			{
				throw new NotImplementedException();
			}
		}

		private static void SaveValue(XmlWriter writer, ENCredentialStore value)
		{
			if (value == null)
				writer.WriteAttributeString("null", "true");
			else
				value.Save(writer);
		}

		private static void SaveValue(XmlWriter writer, List<string> value)
		{
			if (value == null)
			{
				writer.WriteAttributeString("null", "true");
				return;
			}

			foreach (string item in value)
			{
				writer.WriteStartElement("Value");
				if (item == null)
					writer.WriteAttributeString("null", "true");
				else
					writer.WriteString(item);
				writer.WriteEndElement();
			}
		}

		private static void SaveValue(XmlWriter writer, User value)
		{
			if (value == null)
			{
				writer.WriteAttributeString("null", "true");
				return;
			}

			writer.WriteStartElement("__isset");
			SaveValue(writer, value.__isset);
			writer.WriteEndElement();
			writer.WriteStartElement("Accounting");
			SaveValue(writer, value.Accounting);
			writer.WriteEndElement();
			writer.WriteStartElement("AccountLimits");
			SaveValue(writer, value.AccountLimits);
			writer.WriteEndElement();
			writer.WriteStartElement("Active");
			writer.WriteString(XmlConvert.ToString(value.Active));
			writer.WriteEndElement();
			writer.WriteStartElement("Attributes");
			SaveValue(writer, value.Attributes);
			writer.WriteEndElement();
			writer.WriteStartElement("BusinessUserInfo");
			SaveValue(writer, value.BusinessUserInfo);
			writer.WriteEndElement();
			writer.WriteStartElement("Created");
			writer.WriteString(XmlConvert.ToString(value.Created));
			writer.WriteEndElement();
			writer.WriteStartElement("Deleted");
			writer.WriteString(XmlConvert.ToString(value.Deleted));
			writer.WriteEndElement();
			writer.WriteStartElement("Email");
			if (value.Email == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.Email);
			writer.WriteEndElement();
			writer.WriteStartElement("Id");
			writer.WriteString(XmlConvert.ToString(value.Id));
			writer.WriteEndElement();
			writer.WriteStartElement("Name");
			if (value.Name == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.Name);
			writer.WriteEndElement();
			writer.WriteStartElement("PhotoLastUpdated");
			writer.WriteString(XmlConvert.ToString(value.PhotoLastUpdated));
			writer.WriteEndElement();
			writer.WriteStartElement("PhotoUrl");
			if (value.PhotoUrl == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.PhotoUrl);
			writer.WriteEndElement();
			writer.WriteStartElement("Privilege");
			writer.WriteString(Enum.GetName(value.Privilege));
			writer.WriteEndElement();
			writer.WriteStartElement("ServiceLevel");
			writer.WriteString(Enum.GetName(value.ServiceLevel));
			writer.WriteEndElement();
			writer.WriteStartElement("ShardId");
			if (value.ShardId == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.ShardId);
			writer.WriteEndElement();
			writer.WriteStartElement("Timezone");
			if (value.Timezone == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.Timezone);
			writer.WriteEndElement();
			writer.WriteStartElement("Updated");
			writer.WriteString(XmlConvert.ToString(value.Updated));
			writer.WriteEndElement();
			writer.WriteStartElement("Username");
			if (value.Username == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.Username);
			writer.WriteEndElement();
		}

		private static void SaveValue(XmlWriter writer, User.Isset value)
		{
			writer.WriteStartElement("accounting");
			writer.WriteString(XmlConvert.ToString(value.accounting));
			writer.WriteEndElement();
			writer.WriteStartElement("accountLimits");
			writer.WriteString(XmlConvert.ToString(value.accountLimits));
			writer.WriteEndElement();
			writer.WriteStartElement("active");
			writer.WriteString(XmlConvert.ToString(value.active));
			writer.WriteEndElement();
			writer.WriteStartElement("attributes");
			writer.WriteString(XmlConvert.ToString(value.attributes));
			writer.WriteEndElement();
			writer.WriteStartElement("businessUserInfo");
			writer.WriteString(XmlConvert.ToString(value.businessUserInfo));
			writer.WriteEndElement();
			writer.WriteStartElement("created");
			writer.WriteString(XmlConvert.ToString(value.created));
			writer.WriteEndElement();
			writer.WriteStartElement("deleted");
			writer.WriteString(XmlConvert.ToString(value.deleted));
			writer.WriteEndElement();
			writer.WriteStartElement("email");
			writer.WriteString(XmlConvert.ToString(value.email));
			writer.WriteEndElement();
			writer.WriteStartElement("id");
			writer.WriteString(XmlConvert.ToString(value.id));
			writer.WriteEndElement();
			writer.WriteStartElement("name");
			writer.WriteString(XmlConvert.ToString(value.name));
			writer.WriteEndElement();
			writer.WriteStartElement("photoLastUpdated");
			writer.WriteString(XmlConvert.ToString(value.photoLastUpdated));
			writer.WriteEndElement();
			writer.WriteStartElement("photoUrl");
			writer.WriteString(XmlConvert.ToString(value.photoUrl));
			writer.WriteEndElement();
			writer.WriteStartElement("privilege");
			writer.WriteString(XmlConvert.ToString(value.privilege));
			writer.WriteEndElement();
			writer.WriteStartElement("serviceLevel");
			writer.WriteString(XmlConvert.ToString(value.serviceLevel));
			writer.WriteEndElement();
			writer.WriteStartElement("shardId");
			writer.WriteString(XmlConvert.ToString(value.shardId));
			writer.WriteEndElement();
			writer.WriteStartElement("timezone");
			writer.WriteString(XmlConvert.ToString(value.timezone));
			writer.WriteEndElement();
			writer.WriteStartElement("updated");
			writer.WriteString(XmlConvert.ToString(value.updated));
			writer.WriteEndElement();
			writer.WriteStartElement("username");
			writer.WriteString(XmlConvert.ToString(value.username));
			writer.WriteEndElement();
		}

		private static void SaveValue(XmlWriter writer, Accounting value)
		{
			if (value == null)
			{
				writer.WriteAttributeString("null", "true");
				return;
			}

			writer.WriteStartElement("__isset");
			SaveValue(writer, value.__isset);
			writer.WriteEndElement();
			writer.WriteStartElement("AvailablePoints");
			writer.WriteString(XmlConvert.ToString(value.AvailablePoints));
			writer.WriteEndElement();
			writer.WriteStartElement("BusinessId");
			writer.WriteString(XmlConvert.ToString(value.BusinessId));
			writer.WriteEndElement();
			writer.WriteStartElement("BusinessName");
			if (value.BusinessName == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.BusinessName);
			writer.WriteEndElement();
			writer.WriteStartElement("BusinessRole");
			writer.WriteString(Enum.GetName(value.BusinessRole));
			writer.WriteEndElement();
			writer.WriteStartElement("Currency");
			if (value.Currency == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.Currency);
			writer.WriteEndElement();
			writer.WriteStartElement("LastFailedCharge");
			writer.WriteString(XmlConvert.ToString(value.LastFailedCharge));
			writer.WriteEndElement();
			writer.WriteStartElement("LastFailedChargeReason");
			if (value.LastFailedChargeReason == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.LastFailedChargeReason);
			writer.WriteEndElement();
			writer.WriteStartElement("LastRequestedCharge");
			writer.WriteString(XmlConvert.ToString(value.LastRequestedCharge));
			writer.WriteEndElement();
			writer.WriteStartElement("LastSuccessfulCharge");
			writer.WriteString(XmlConvert.ToString(value.LastSuccessfulCharge));
			writer.WriteEndElement();
			writer.WriteStartElement("NextChargeDate");
			writer.WriteString(XmlConvert.ToString(value.NextChargeDate));
			writer.WriteEndElement();
			writer.WriteStartElement("NextPaymentDue");
			writer.WriteString(XmlConvert.ToString(value.NextPaymentDue));
			writer.WriteEndElement();
			writer.WriteStartElement("PremiumCommerceService");
			if (value.PremiumCommerceService == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.PremiumCommerceService);
			writer.WriteEndElement();
			writer.WriteStartElement("PremiumLockUntil");
			writer.WriteString(XmlConvert.ToString(value.PremiumLockUntil));
			writer.WriteEndElement();
			writer.WriteStartElement("PremiumOrderNumber");
			if (value.PremiumOrderNumber == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.PremiumOrderNumber);
			writer.WriteEndElement();
			writer.WriteStartElement("PremiumServiceSKU");
			if (value.PremiumServiceSKU == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.PremiumServiceSKU);
			writer.WriteEndElement();
			writer.WriteStartElement("PremiumServiceStart");
			writer.WriteString(XmlConvert.ToString(value.PremiumServiceStart));
			writer.WriteEndElement();
			writer.WriteStartElement("PremiumServiceStatus");
			writer.WriteString(Enum.GetName(value.PremiumServiceStatus));
			writer.WriteEndElement();
			writer.WriteStartElement("PremiumSubscriptionNumber");
			if (value.PremiumSubscriptionNumber == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.PremiumSubscriptionNumber);
			writer.WriteEndElement();
			writer.WriteStartElement("UnitDiscount");
			writer.WriteString(XmlConvert.ToString(value.UnitDiscount));
			writer.WriteEndElement();
			writer.WriteStartElement("UnitPrice");
			writer.WriteString(XmlConvert.ToString(value.UnitPrice));
			writer.WriteEndElement();
			writer.WriteStartElement("Updated");
			writer.WriteString(XmlConvert.ToString(value.Updated));
			writer.WriteEndElement();
			writer.WriteStartElement("UploadLimitEnd");
			writer.WriteString(XmlConvert.ToString(value.UploadLimitEnd));
			writer.WriteEndElement();
			writer.WriteStartElement("UploadLimitNextMonth");
			writer.WriteString(XmlConvert.ToString(value.UploadLimitNextMonth));
			writer.WriteEndElement();
		}

		private static void SaveValue(XmlWriter writer, Accounting.Isset value)
		{
			writer.WriteStartElement("availablePoints");
			writer.WriteString(XmlConvert.ToString(value.availablePoints));
			writer.WriteEndElement();
			writer.WriteStartElement("businessId");
			writer.WriteString(XmlConvert.ToString(value.businessId));
			writer.WriteEndElement();
			writer.WriteStartElement("businessName");
			writer.WriteString(XmlConvert.ToString(value.businessName));
			writer.WriteEndElement();
			writer.WriteStartElement("businessRole");
			writer.WriteString(XmlConvert.ToString(value.businessRole));
			writer.WriteEndElement();
			writer.WriteStartElement("currency");
			writer.WriteString(XmlConvert.ToString(value.currency));
			writer.WriteEndElement();
			writer.WriteStartElement("lastFailedCharge");
			writer.WriteString(XmlConvert.ToString(value.lastFailedCharge));
			writer.WriteEndElement();
			writer.WriteStartElement("lastFailedChargeReason");
			writer.WriteString(XmlConvert.ToString(value.lastFailedChargeReason));
			writer.WriteEndElement();
			writer.WriteStartElement("lastRequestedCharge");
			writer.WriteString(XmlConvert.ToString(value.lastRequestedCharge));
			writer.WriteEndElement();
			writer.WriteStartElement("lastSuccessfulCharge");
			writer.WriteString(XmlConvert.ToString(value.lastSuccessfulCharge));
			writer.WriteEndElement();
			writer.WriteStartElement("nextChargeDate");
			writer.WriteString(XmlConvert.ToString(value.nextChargeDate));
			writer.WriteEndElement();
			writer.WriteStartElement("nextPaymentDue");
			writer.WriteString(XmlConvert.ToString(value.nextPaymentDue));
			writer.WriteEndElement();
			writer.WriteStartElement("premiumCommerceService");
			writer.WriteString(XmlConvert.ToString(value.premiumCommerceService));
			writer.WriteEndElement();
			writer.WriteStartElement("premiumLockUntil");
			writer.WriteString(XmlConvert.ToString(value.premiumLockUntil));
			writer.WriteEndElement();
			writer.WriteStartElement("premiumOrderNumber");
			writer.WriteString(XmlConvert.ToString(value.premiumOrderNumber));
			writer.WriteEndElement();
			writer.WriteStartElement("premiumServiceSKU");
			writer.WriteString(XmlConvert.ToString(value.premiumServiceSKU));
			writer.WriteEndElement();
			writer.WriteStartElement("premiumServiceStart");
			writer.WriteString(XmlConvert.ToString(value.premiumServiceStart));
			writer.WriteEndElement();
			writer.WriteStartElement("premiumServiceStatus");
			writer.WriteString(XmlConvert.ToString(value.premiumServiceStatus));
			writer.WriteEndElement();
			writer.WriteStartElement("premiumSubscriptionNumber");
			writer.WriteString(XmlConvert.ToString(value.premiumSubscriptionNumber));
			writer.WriteEndElement();
			writer.WriteStartElement("unitDiscount");
			writer.WriteString(XmlConvert.ToString(value.unitDiscount));
			writer.WriteEndElement();
			writer.WriteStartElement("unitPrice");
			writer.WriteString(XmlConvert.ToString(value.unitPrice));
			writer.WriteEndElement();
			writer.WriteStartElement("updated");
			writer.WriteString(XmlConvert.ToString(value.updated));
			writer.WriteEndElement();
			writer.WriteStartElement("uploadLimitEnd");
			writer.WriteString(XmlConvert.ToString(value.uploadLimitEnd));
			writer.WriteEndElement();
			writer.WriteStartElement("uploadLimitNextMonth");
			writer.WriteString(XmlConvert.ToString(value.uploadLimitNextMonth));
			writer.WriteEndElement();
		}

		private static void SaveValue(XmlWriter writer, AccountLimits value)
		{
			if (value == null)
			{
				writer.WriteAttributeString("null", "true");
				return;
			}

			writer.WriteStartElement("__isset");
			SaveValue(writer, value.__isset);
			writer.WriteEndElement();
			writer.WriteStartElement("NoteResourceCountMax");
			writer.WriteString(XmlConvert.ToString(value.NoteResourceCountMax));
			writer.WriteEndElement();
			writer.WriteStartElement("NoteSizeMax");
			writer.WriteString(XmlConvert.ToString(value.NoteSizeMax));
			writer.WriteEndElement();
			writer.WriteStartElement("NoteTagCountMax");
			writer.WriteString(XmlConvert.ToString(value.NoteTagCountMax));
			writer.WriteEndElement();
			writer.WriteStartElement("ResourceSizeMax");
			writer.WriteString(XmlConvert.ToString(value.ResourceSizeMax));
			writer.WriteEndElement();
			writer.WriteStartElement("UploadLimit");
			writer.WriteString(XmlConvert.ToString(value.UploadLimit));
			writer.WriteEndElement();
			writer.WriteStartElement("UserLinkedNotebookMax");
			writer.WriteString(XmlConvert.ToString(value.UserLinkedNotebookMax));
			writer.WriteEndElement();
			writer.WriteStartElement("UserMailLimitDaily");
			writer.WriteString(XmlConvert.ToString(value.UserMailLimitDaily));
			writer.WriteEndElement();
			writer.WriteStartElement("UserNotebookCountMax");
			writer.WriteString(XmlConvert.ToString(value.UserNotebookCountMax));
			writer.WriteEndElement();
			writer.WriteStartElement("UserNoteCountMax");
			writer.WriteString(XmlConvert.ToString(value.UserNoteCountMax));
			writer.WriteEndElement();
			writer.WriteStartElement("UserSavedSearchesMax");
			writer.WriteString(XmlConvert.ToString(value.UserSavedSearchesMax));
			writer.WriteEndElement();
			writer.WriteStartElement("UserTagCountMax");
			writer.WriteString(XmlConvert.ToString(value.UserTagCountMax));
			writer.WriteEndElement();
		}

		private static void SaveValue(XmlWriter writer, AccountLimits.Isset value)
		{
			writer.WriteStartElement("noteResourceCountMax");
			writer.WriteString(XmlConvert.ToString(value.noteResourceCountMax));
			writer.WriteEndElement();
			writer.WriteStartElement("noteSizeMax");
			writer.WriteString(XmlConvert.ToString(value.noteSizeMax));
			writer.WriteEndElement();
			writer.WriteStartElement("noteTagCountMax");
			writer.WriteString(XmlConvert.ToString(value.noteTagCountMax));
			writer.WriteEndElement();
			writer.WriteStartElement("resourceSizeMax");
			writer.WriteString(XmlConvert.ToString(value.resourceSizeMax));
			writer.WriteEndElement();
			writer.WriteStartElement("uploadLimit");
			writer.WriteString(XmlConvert.ToString(value.uploadLimit));
			writer.WriteEndElement();
			writer.WriteStartElement("userLinkedNotebookMax");
			writer.WriteString(XmlConvert.ToString(value.userLinkedNotebookMax));
			writer.WriteEndElement();
			writer.WriteStartElement("userMailLimitDaily");
			writer.WriteString(XmlConvert.ToString(value.userMailLimitDaily));
			writer.WriteEndElement();
			writer.WriteStartElement("userNotebookCountMax");
			writer.WriteString(XmlConvert.ToString(value.userNotebookCountMax));
			writer.WriteEndElement();
			writer.WriteStartElement("userNoteCountMax");
			writer.WriteString(XmlConvert.ToString(value.userNoteCountMax));
			writer.WriteEndElement();
			writer.WriteStartElement("userSavedSearchesMax");
			writer.WriteString(XmlConvert.ToString(value.userSavedSearchesMax));
			writer.WriteEndElement();
			writer.WriteStartElement("userTagCountMax");
			writer.WriteString(XmlConvert.ToString(value.userTagCountMax));
			writer.WriteEndElement();
		}

		private static void SaveValue(XmlWriter writer, UserAttributes value)
		{
			if (value == null)
			{
				writer.WriteAttributeString("null", "true");
				return;
			}

			writer.WriteStartElement("__isset");
			SaveValue(writer, value.__isset);
			writer.WriteEndElement();
			writer.WriteStartElement("BusinessAddress");
			if (value.BusinessAddress == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.BusinessAddress);
			writer.WriteEndElement();
			writer.WriteStartElement("ClipFullPage");
			writer.WriteString(XmlConvert.ToString(value.ClipFullPage));
			writer.WriteEndElement();
			writer.WriteStartElement("Comments");
			if (value.Comments == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.Comments);
			writer.WriteEndElement();
			writer.WriteStartElement("DailyEmailLimit");
			writer.WriteString(XmlConvert.ToString(value.DailyEmailLimit));
			writer.WriteEndElement();
			writer.WriteStartElement("DateAgreedToTermsOfService");
			writer.WriteString(XmlConvert.ToString(value.DateAgreedToTermsOfService));
			writer.WriteEndElement();
			writer.WriteStartElement("DefaultLatitude");
			writer.WriteString(XmlConvert.ToString(value.DefaultLatitude));
			writer.WriteEndElement();
			writer.WriteStartElement("DefaultLocationName");
			if (value.DefaultLocationName == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.DefaultLocationName);
			writer.WriteEndElement();
			writer.WriteStartElement("DefaultLongitude");
			writer.WriteString(XmlConvert.ToString(value.DefaultLongitude));
			writer.WriteEndElement();
			writer.WriteStartElement("EducationalDiscount");
			writer.WriteString(XmlConvert.ToString(value.EducationalDiscount));
			writer.WriteEndElement();
			writer.WriteStartElement("EmailAddressLastConfirmed");
			writer.WriteString(XmlConvert.ToString(value.EmailAddressLastConfirmed));
			writer.WriteEndElement();
			writer.WriteStartElement("EmailOptOutDate");
			writer.WriteString(XmlConvert.ToString(value.EmailOptOutDate));
			writer.WriteEndElement();
			writer.WriteStartElement("GroupName");
			if (value.GroupName == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.GroupName);
			writer.WriteEndElement();
			writer.WriteStartElement("HideSponsorBilling");
			writer.WriteString(XmlConvert.ToString(value.HideSponsorBilling));
			writer.WriteEndElement();
			writer.WriteStartElement("IncomingEmailAddress");
			if (value.IncomingEmailAddress == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.IncomingEmailAddress);
			writer.WriteEndElement();
			writer.WriteStartElement("MaxReferrals");
			writer.WriteString(XmlConvert.ToString(value.MaxReferrals));
			writer.WriteEndElement();
			writer.WriteStartElement("OptOutMachineLearning");
			writer.WriteString(XmlConvert.ToString(value.OptOutMachineLearning));
			writer.WriteEndElement();
			writer.WriteStartElement("PartnerEmailOptInDate");
			writer.WriteString(XmlConvert.ToString(value.PartnerEmailOptInDate));
			writer.WriteEndElement();
			writer.WriteStartElement("PasswordUpdated");
			writer.WriteString(XmlConvert.ToString(value.PasswordUpdated));
			writer.WriteEndElement();
			writer.WriteStartElement("Preactivation");
			writer.WriteString(XmlConvert.ToString(value.Preactivation));
			writer.WriteEndElement();
			writer.WriteStartElement("PreferredCountry");
			if (value.PreferredCountry == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.PreferredCountry);
			writer.WriteEndElement();
			writer.WriteStartElement("PreferredLanguage");
			if (value.PreferredLanguage == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.PreferredLanguage);
			writer.WriteEndElement();
			writer.WriteStartElement("RecentMailedAddresses");
			SaveValue(writer, value.RecentMailedAddresses);
			writer.WriteEndElement();
			writer.WriteStartElement("RecognitionLanguage");
			if (value.RecognitionLanguage == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.RecognitionLanguage);
			writer.WriteEndElement();
			writer.WriteStartElement("RefererCode");
			if (value.RefererCode == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.RefererCode);
			writer.WriteEndElement();
			writer.WriteStartElement("ReferralCount");
			writer.WriteString(XmlConvert.ToString(value.ReferralCount));
			writer.WriteEndElement();
			writer.WriteStartElement("ReferralProof");
			if (value.ReferralProof == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.ReferralProof);
			writer.WriteEndElement();
			writer.WriteStartElement("ReminderEmailConfig");
			writer.WriteString(Enum.GetName(value.ReminderEmailConfig));
			writer.WriteEndElement();
			writer.WriteStartElement("SalesforcePushEnabled");
			writer.WriteString(XmlConvert.ToString(value.SalesforcePushEnabled));
			writer.WriteEndElement();
			writer.WriteStartElement("SentEmailCount");
			writer.WriteString(XmlConvert.ToString(value.SentEmailCount));
			writer.WriteEndElement();
			writer.WriteStartElement("SentEmailDate");
			writer.WriteString(XmlConvert.ToString(value.SentEmailDate));
			writer.WriteEndElement();
			writer.WriteStartElement("ShouldLogClientEvent");
			writer.WriteString(XmlConvert.ToString(value.ShouldLogClientEvent));
			writer.WriteEndElement();
			writer.WriteStartElement("TwitterId");
			if (value.TwitterId == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.TwitterId);
			writer.WriteEndElement();
			writer.WriteStartElement("TwitterUserName");
			if (value.TwitterUserName == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.TwitterUserName);
			writer.WriteEndElement();
			writer.WriteStartElement("UseEmailAutoFiling");
			writer.WriteString(XmlConvert.ToString(value.UseEmailAutoFiling));
			writer.WriteEndElement();
			writer.WriteStartElement("ViewedPromotions");
			SaveValue(writer, value.ViewedPromotions);
			writer.WriteEndElement();
		}

		private static void SaveValue(XmlWriter writer, UserAttributes.Isset value)
		{
			writer.WriteStartElement("businessAddress");
			writer.WriteString(XmlConvert.ToString(value.businessAddress));
			writer.WriteEndElement();
			writer.WriteStartElement("clipFullPage");
			writer.WriteString(XmlConvert.ToString(value.clipFullPage));
			writer.WriteEndElement();
			writer.WriteStartElement("comments");
			writer.WriteString(XmlConvert.ToString(value.comments));
			writer.WriteEndElement();
			writer.WriteStartElement("dailyEmailLimit");
			writer.WriteString(XmlConvert.ToString(value.dailyEmailLimit));
			writer.WriteEndElement();
			writer.WriteStartElement("dateAgreedToTermsOfService");
			writer.WriteString(XmlConvert.ToString(value.dateAgreedToTermsOfService));
			writer.WriteEndElement();
			writer.WriteStartElement("defaultLatitude");
			writer.WriteString(XmlConvert.ToString(value.defaultLatitude));
			writer.WriteEndElement();
			writer.WriteStartElement("defaultLocationName");
			writer.WriteString(XmlConvert.ToString(value.defaultLocationName));
			writer.WriteEndElement();
			writer.WriteStartElement("defaultLongitude");
			writer.WriteString(XmlConvert.ToString(value.defaultLongitude));
			writer.WriteEndElement();
			writer.WriteStartElement("educationalDiscount");
			writer.WriteString(XmlConvert.ToString(value.educationalDiscount));
			writer.WriteEndElement();
			writer.WriteStartElement("emailAddressLastConfirmed");
			writer.WriteString(XmlConvert.ToString(value.emailAddressLastConfirmed));
			writer.WriteEndElement();
			writer.WriteStartElement("emailOptOutDate");
			writer.WriteString(XmlConvert.ToString(value.emailOptOutDate));
			writer.WriteEndElement();
			writer.WriteStartElement("groupName");
			writer.WriteString(XmlConvert.ToString(value.groupName));
			writer.WriteEndElement();
			writer.WriteStartElement("hideSponsorBilling");
			writer.WriteString(XmlConvert.ToString(value.hideSponsorBilling));
			writer.WriteEndElement();
			writer.WriteStartElement("incomingEmailAddress");
			writer.WriteString(XmlConvert.ToString(value.incomingEmailAddress));
			writer.WriteEndElement();
			writer.WriteStartElement("maxReferrals");
			writer.WriteString(XmlConvert.ToString(value.maxReferrals));
			writer.WriteEndElement();
			writer.WriteStartElement("optOutMachineLearning");
			writer.WriteString(XmlConvert.ToString(value.optOutMachineLearning));
			writer.WriteEndElement();
			writer.WriteStartElement("partnerEmailOptInDate");
			writer.WriteString(XmlConvert.ToString(value.partnerEmailOptInDate));
			writer.WriteEndElement();
			writer.WriteStartElement("passwordUpdated");
			writer.WriteString(XmlConvert.ToString(value.passwordUpdated));
			writer.WriteEndElement();
			writer.WriteStartElement("preactivation");
			writer.WriteString(XmlConvert.ToString(value.preactivation));
			writer.WriteEndElement();
			writer.WriteStartElement("preferredCountry");
			writer.WriteString(XmlConvert.ToString(value.preferredCountry));
			writer.WriteEndElement();
			writer.WriteStartElement("preferredLanguage");
			writer.WriteString(XmlConvert.ToString(value.preferredLanguage));
			writer.WriteEndElement();
			writer.WriteStartElement("recentMailedAddresses");
			writer.WriteString(XmlConvert.ToString(value.recentMailedAddresses));
			writer.WriteEndElement();
			writer.WriteStartElement("recognitionLanguage");
			writer.WriteString(XmlConvert.ToString(value.recognitionLanguage));
			writer.WriteEndElement();
			writer.WriteStartElement("refererCode");
			writer.WriteString(XmlConvert.ToString(value.refererCode));
			writer.WriteEndElement();
			writer.WriteStartElement("referralCount");
			writer.WriteString(XmlConvert.ToString(value.referralCount));
			writer.WriteEndElement();
			writer.WriteStartElement("referralProof");
			writer.WriteString(XmlConvert.ToString(value.referralProof));
			writer.WriteEndElement();
			writer.WriteStartElement("reminderEmailConfig");
			writer.WriteString(XmlConvert.ToString(value.reminderEmailConfig));
			writer.WriteEndElement();
			writer.WriteStartElement("salesforcePushEnabled");
			writer.WriteString(XmlConvert.ToString(value.salesforcePushEnabled));
			writer.WriteEndElement();
			writer.WriteStartElement("sentEmailCount");
			writer.WriteString(XmlConvert.ToString(value.sentEmailCount));
			writer.WriteEndElement();
			writer.WriteStartElement("sentEmailDate");
			writer.WriteString(XmlConvert.ToString(value.sentEmailDate));
			writer.WriteEndElement();
			writer.WriteStartElement("shouldLogClientEvent");
			writer.WriteString(XmlConvert.ToString(value.shouldLogClientEvent));
			writer.WriteEndElement();
			writer.WriteStartElement("twitterId");
			writer.WriteString(XmlConvert.ToString(value.twitterId));
			writer.WriteEndElement();
			writer.WriteStartElement("twitterUserName");
			writer.WriteString(XmlConvert.ToString(value.twitterUserName));
			writer.WriteEndElement();
			writer.WriteStartElement("useEmailAutoFiling");
			writer.WriteString(XmlConvert.ToString(value.useEmailAutoFiling));
			writer.WriteEndElement();
			writer.WriteStartElement("viewedPromotions");
			writer.WriteString(XmlConvert.ToString(value.viewedPromotions));
			writer.WriteEndElement();
		}

		private static void SaveValue(XmlWriter writer, BusinessUserInfo value)
		{
			if (value == null)
			{
				writer.WriteAttributeString("null", "true");
				return;
			}

			writer.WriteStartElement("__isset");
			SaveValue(writer, value.__isset);
			writer.WriteEndElement();
			writer.WriteStartElement("BusinessId");
			writer.WriteString(XmlConvert.ToString(value.BusinessId));
			writer.WriteEndElement();
			writer.WriteStartElement("BusinessName");
			if (value.BusinessName == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.BusinessName);
			writer.WriteEndElement();
			writer.WriteStartElement("Email");
			if (value.Email == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.Email);
			writer.WriteEndElement();
			writer.WriteStartElement("Role");
			writer.WriteString(Enum.GetName(value.Role));
			writer.WriteEndElement();
			writer.WriteStartElement("Updated");
			writer.WriteString(XmlConvert.ToString(value.Updated));
			writer.WriteEndElement();
		}

		private static void SaveValue(XmlWriter writer, BusinessUserInfo.Isset value)
		{
			writer.WriteStartElement("businessId");
			writer.WriteString(XmlConvert.ToString(value.businessId));
			writer.WriteEndElement();
			writer.WriteStartElement("businessName");
			writer.WriteString(XmlConvert.ToString(value.businessName));
			writer.WriteEndElement();
			writer.WriteStartElement("email");
			writer.WriteString(XmlConvert.ToString(value.email));
			writer.WriteEndElement();
			writer.WriteStartElement("role");
			writer.WriteString(XmlConvert.ToString(value.role));
			writer.WriteEndElement();
			writer.WriteStartElement("updated");
			writer.WriteString(XmlConvert.ToString(value.updated));
			writer.WriteEndElement();
		}

		private static void SaveValue(XmlWriter writer, LinkedNotebook value)
		{
			if (value == null)
			{
				writer.WriteAttributeString("null", "true");
				return;
			}

			writer.WriteStartElement("__isset");
			SaveValue(writer, value.__isset);
			writer.WriteEndElement();
			writer.WriteStartElement("BusinessId");
			writer.WriteString(XmlConvert.ToString(value.BusinessId));
			writer.WriteEndElement();
			writer.WriteStartElement("Guid");
			if (value.Guid == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.Guid);
			writer.WriteEndElement();
			writer.WriteStartElement("NoteStoreUrl");
			if (value.NoteStoreUrl == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.NoteStoreUrl);
			writer.WriteEndElement();
			writer.WriteStartElement("ShardId");
			if (value.ShardId == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.ShardId);
			writer.WriteEndElement();
			writer.WriteStartElement("SharedNotebookGlobalId");
			if (value.SharedNotebookGlobalId == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.SharedNotebookGlobalId);
			writer.WriteEndElement();
			writer.WriteStartElement("ShareName");
			if (value.ShareName == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.ShareName);
			writer.WriteEndElement();
			writer.WriteStartElement("Stack");
			if (value.Stack == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.Stack);
			writer.WriteEndElement();
			writer.WriteStartElement("UpdateSequenceNum");
			writer.WriteString(XmlConvert.ToString(value.UpdateSequenceNum));
			writer.WriteEndElement();
			writer.WriteStartElement("Uri");
			if (value.Uri == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.Uri);
			writer.WriteEndElement();
			writer.WriteStartElement("Username");
			if (value.Username == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.Username);
			writer.WriteEndElement();
			writer.WriteStartElement("WebApiUrlPrefix");
			if (value.WebApiUrlPrefix == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.WebApiUrlPrefix);
			writer.WriteEndElement();
		}

		private static void SaveValue(XmlWriter writer, LinkedNotebook.Isset value)
		{
			writer.WriteStartElement("businessId");
			writer.WriteString(XmlConvert.ToString(value.businessId));
			writer.WriteEndElement();
			writer.WriteStartElement("guid");
			writer.WriteString(XmlConvert.ToString(value.guid));
			writer.WriteEndElement();
			writer.WriteStartElement("noteStoreUrl");
			writer.WriteString(XmlConvert.ToString(value.noteStoreUrl));
			writer.WriteEndElement();
			writer.WriteStartElement("shardId");
			writer.WriteString(XmlConvert.ToString(value.shardId));
			writer.WriteEndElement();
			writer.WriteStartElement("sharedNotebookGlobalId");
			writer.WriteString(XmlConvert.ToString(value.sharedNotebookGlobalId));
			writer.WriteEndElement();
			writer.WriteStartElement("shareName");
			writer.WriteString(XmlConvert.ToString(value.shareName));
			writer.WriteEndElement();
			writer.WriteStartElement("stack");
			writer.WriteString(XmlConvert.ToString(value.stack));
			writer.WriteEndElement();
			writer.WriteStartElement("updateSequenceNum");
			writer.WriteString(XmlConvert.ToString(value.updateSequenceNum));
			writer.WriteEndElement();
			writer.WriteStartElement("uri");
			writer.WriteString(XmlConvert.ToString(value.uri));
			writer.WriteEndElement();
			writer.WriteStartElement("username");
			writer.WriteString(XmlConvert.ToString(value.username));
			writer.WriteEndElement();
			writer.WriteStartElement("webApiUrlPrefix");
			writer.WriteString(XmlConvert.ToString(value.webApiUrlPrefix));
			writer.WriteEndElement();
		}

		private static void SaveValue(XmlWriter writer, SharedNotebook value)
		{
			if (value == null)
			{
				writer.WriteAttributeString("null", "true");
				return;
			}

			writer.WriteStartElement("__isset");
			SaveValue(writer, value.__isset);
			writer.WriteEndElement();
			writer.WriteStartElement("Email");
			if (value.Email == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.Email);
			writer.WriteEndElement();
			writer.WriteStartElement("GlobalId");
			if (value.GlobalId == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.GlobalId);
			writer.WriteEndElement();
			writer.WriteStartElement("Id");
			writer.WriteString(XmlConvert.ToString(value.Id));
			writer.WriteEndElement();
			writer.WriteStartElement("NotebookGuid");
			if (value.NotebookGuid == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.NotebookGuid);
			writer.WriteEndElement();
			writer.WriteStartElement("NotebookModifiable");
			writer.WriteString(XmlConvert.ToString(value.NotebookModifiable));
			writer.WriteEndElement();
			writer.WriteStartElement("Privilege");
			writer.WriteString(Enum.GetName(value.Privilege));
			writer.WriteEndElement();
			writer.WriteStartElement("RecipientIdentityId");
			writer.WriteString(XmlConvert.ToString(value.RecipientIdentityId));
			writer.WriteEndElement();
			writer.WriteStartElement("RecipientSettings");
			SaveValue(writer, value.RecipientSettings);
			writer.WriteEndElement();
			writer.WriteStartElement("RecipientUserId");
			writer.WriteString(XmlConvert.ToString(value.RecipientUserId));
			writer.WriteEndElement();
			writer.WriteStartElement("RecipientUsername");
			if (value.RecipientUsername == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.RecipientUsername);
			writer.WriteEndElement();
			writer.WriteStartElement("ServiceAssigned");
			writer.WriteString(XmlConvert.ToString(value.ServiceAssigned));
			writer.WriteEndElement();
			writer.WriteStartElement("ServiceCreated");
			writer.WriteString(XmlConvert.ToString(value.ServiceCreated));
			writer.WriteEndElement();
			writer.WriteStartElement("ServiceUpdated");
			writer.WriteString(XmlConvert.ToString(value.ServiceUpdated));
			writer.WriteEndElement();
			writer.WriteStartElement("SharerUserId");
			writer.WriteString(XmlConvert.ToString(value.SharerUserId));
			writer.WriteEndElement();
			writer.WriteStartElement("UserId");
			writer.WriteString(XmlConvert.ToString(value.UserId));
			writer.WriteEndElement();
			writer.WriteStartElement("Username");
			if (value.Username == null)
				writer.WriteAttributeString("null", "true");
			else
				writer.WriteString(value.Username);
			writer.WriteEndElement();
		}

		private static void SaveValue(XmlWriter writer, SharedNotebook.Isset value)
		{
			writer.WriteStartElement("email");
			writer.WriteString(XmlConvert.ToString(value.email));
			writer.WriteEndElement();
			writer.WriteStartElement("globalId");
			writer.WriteString(XmlConvert.ToString(value.globalId));
			writer.WriteEndElement();
			writer.WriteStartElement("id");
			writer.WriteString(XmlConvert.ToString(value.id));
			writer.WriteEndElement();
			writer.WriteStartElement("notebookGuid");
			writer.WriteString(XmlConvert.ToString(value.notebookGuid));
			writer.WriteEndElement();
			writer.WriteStartElement("notebookModifiable");
			writer.WriteString(XmlConvert.ToString(value.notebookModifiable));
			writer.WriteEndElement();
			writer.WriteStartElement("privilege");
			writer.WriteString(XmlConvert.ToString(value.privilege));
			writer.WriteEndElement();
			writer.WriteStartElement("recipientIdentityId");
			writer.WriteString(XmlConvert.ToString(value.recipientIdentityId));
			writer.WriteEndElement();
			writer.WriteStartElement("recipientSettings");
			writer.WriteString(XmlConvert.ToString(value.recipientSettings));
			writer.WriteEndElement();
			writer.WriteStartElement("recipientUserId");
			writer.WriteString(XmlConvert.ToString(value.recipientUserId));
			writer.WriteEndElement();
			writer.WriteStartElement("recipientUsername");
			writer.WriteString(XmlConvert.ToString(value.recipientUsername));
			writer.WriteEndElement();
			writer.WriteStartElement("serviceAssigned");
			writer.WriteString(XmlConvert.ToString(value.serviceAssigned));
			writer.WriteEndElement();
			writer.WriteStartElement("serviceCreated");
			writer.WriteString(XmlConvert.ToString(value.serviceCreated));
			writer.WriteEndElement();
			writer.WriteStartElement("serviceUpdated");
			writer.WriteString(XmlConvert.ToString(value.serviceUpdated));
			writer.WriteEndElement();
			writer.WriteStartElement("sharerUserId");
			writer.WriteString(XmlConvert.ToString(value.sharerUserId));
			writer.WriteEndElement();
			writer.WriteStartElement("userId");
			writer.WriteString(XmlConvert.ToString(value.userId));
			writer.WriteEndElement();
			writer.WriteStartElement("username");
			writer.WriteString(XmlConvert.ToString(value.username));
			writer.WriteEndElement();
		}

		private static void SaveValue(XmlWriter writer, SharedNotebookRecipientSettings value)
		{
			if (value == null)
			{
				writer.WriteAttributeString("null", "true");
				return;
			}

			writer.WriteStartElement("__isset");
			SaveValue(writer, value.__isset);
			writer.WriteEndElement();
			writer.WriteStartElement("ReminderNotifyEmail");
			writer.WriteString(XmlConvert.ToString(value.ReminderNotifyEmail));
			writer.WriteEndElement();
			writer.WriteStartElement("ReminderNotifyInApp");
			writer.WriteString(XmlConvert.ToString(value.ReminderNotifyInApp));
			writer.WriteEndElement();
		}

		private static void SaveValue(XmlWriter writer, SharedNotebookRecipientSettings.Isset value)
		{
			writer.WriteStartElement("reminderNotifyEmail");
			writer.WriteString(XmlConvert.ToString(value.reminderNotifyEmail));
			writer.WriteEndElement();
			writer.WriteStartElement("reminderNotifyInApp");
			writer.WriteString(XmlConvert.ToString(value.reminderNotifyInApp));
			writer.WriteEndElement();
		}

		public static Dictionary<string, object> Load(string filename)
		{
			XmlDocument document = new XmlDocument();
			document.Load(filename);
			return Load(document);
		}

		public static Dictionary<string, object> Load(XmlDocument document)
        {
			if (document.DocumentElement.LocalName != "EvernotePreferences")
				return null;
			if (document.DocumentElement.GetAttribute("null") == "true")
				return null;
			Dictionary<string, object> result = new Dictionary<string,object>();


            foreach (XmlElement item in document.DocumentElement.ChildNodes.OfType<XmlElement>())
            {
				object value;
				string type = item.GetAttribute("type");
                switch (type)
                {
					case "bool":
						value = XmlConvert.ToBoolean(item.InnerText);
						break;
					case "string":
						value = item.InnerText;
						break;
					case "user":
						value = item.LoadUser();
						break;
					case "linked-notebook":
						value = item.LoadLinkedNotebook();
						break;
					case "shared-notebook":
						value = item.LoadSharedNotebook();
						break;
					case "credential-store":
						value = item.LoadENCredentialStore();
						break;
					case "null":
						value = null;
						break;
					default:
						throw new NotImplementedException();
                }
				result.Add(item.Name, value);
            }

			return result;
		}

		private static ENCredentialStore LoadENCredentialStore(this XmlElement element)
        {
			if (element == null)
				return default(ENCredentialStore);
			ENCredentialStore result = new ENCredentialStore();
			result.Load(element);
			return result;
		}

		public static ENCredentials LoadENCredentials(this XmlElement element)
		{
			if (element == null)
				return null;
			if (element.GetAttribute("null") == "true")
				return null;
			return new ENCredentials(
				element.LoadString("Host"),
				element.LoadString("EdamUserId"),
				element.LoadString("NoteStoreUrl"),
				element.LoadString("WebApiUrlPrefix"),
				null,
				element.LoadDateTime("ExpirationDate"));
		}

		private static string LoadString(this XmlElement parent, string name)
		{
			XmlElement element = parent.GetElement(name);
			if (element == null)
				return null;
			if (element.GetAttribute("null") == "true")
				return null;
			return element.InnerText;
		}

		private static int LoadInt32(this XmlElement parent, string name)
		{
			return Load(parent, name, XmlConvert.ToInt32);
		}


		private static long LoadInt64(this XmlElement parent, string name)
		{
			return Load(parent, name, XmlConvert.ToInt64);
		}

		private static double LoadDouble(this XmlElement parent, string name)
		{
			return Load(parent, name, XmlConvert.ToDouble);
		}

		private static bool LoadBool(this XmlElement parent, string name)
		{
			return Load(parent, name, XmlConvert.ToBoolean);
		}

		private static DateTime LoadDateTime(this XmlElement parent, string name)
		{
			return Load(parent, name, xml => XmlConvert.ToDateTime(xml, XmlDateTimeSerializationMode.RoundtripKind));
		}

		private static T Load<T>(this XmlElement parent, string name, Func<string, T> access)
		{
			XmlElement element = parent.GetElement(name);
			if (element == null)
				return default(T);
			return access.Invoke(element.InnerText);
		}

		private static T LoadEnum<T>(this XmlElement parent, string name)
			where T : struct
		{
			XmlElement element = parent.GetElement(name);
			if (element == null)
				return default(T);
			Enum.TryParse(element.InnerText, out T value);
			return value;
		}

		private static List<string> LoadStringList(this XmlElement parent, string name)
        {
			XmlElement element = parent.GetElement(name);
			if (element == null)
				return null;
			if (element.GetAttribute("null") == "true")
				return null;
			List<string> list = new List<string>();

			foreach (XmlElement item in element.GetElementsByTagName("Value"))
            {
				if ((item == null) || (item.GetAttribute("null") == "true"))
					list.Add(null);
				else
					list.Add(item.InnerText);
            }
			return list;
		}

		private static User LoadUser(this XmlElement element)
		{
			if (element == null)
				return default(User);
			if (element.GetAttribute("null") == "true")
				return default(User);

			User value = new User();

			value.Accounting = element.LoadAccounting("Accounting");
			value.AccountLimits = element.LoadAccountLimits("AccountLimits");
			value.Active = element.LoadBool("Active");
			value.Attributes = element.LoadUserAttributes("Attributes");
			value.BusinessUserInfo = element.LoadBusinessUserInfo("BusinessUserInfo");
			value.Created = element.LoadInt64("Created");
			value.Deleted = element.LoadInt64("Deleted");
			value.Email = element.LoadString("Email");
			value.Id = element.LoadInt32("Id");
			value.Name = element.LoadString("Name");
			value.PhotoLastUpdated = element.LoadInt64("PhotoLastUpdated");
			value.PhotoUrl = element.LoadString("PhotoUrl");
			value.Privilege = element.LoadEnum<PrivilegeLevel>("Privilege");
			value.ServiceLevel = element.LoadEnum<ServiceLevel>("ServiceLevel");
			value.ShardId = element.LoadString("ShardId");
			value.Timezone = element.LoadString("Timezone");
			value.Updated = element.LoadInt64("Updated");
			value.Username = element.LoadString("Username");
			value.__isset = element.LoadUser_Isset("__isset");

			return value;
		}

		private static User.Isset LoadUser_Isset(this XmlElement parent, string name)
		{
			XmlElement element = parent.GetElement(name);
			if (element == null)
				return default(User.Isset);

			User.Isset value = new User.Isset();

			value.accounting = element.LoadBool("accounting");
			value.accountLimits = element.LoadBool("accountLimits");
			value.active = element.LoadBool("active");
			value.attributes = element.LoadBool("attributes");
			value.businessUserInfo = element.LoadBool("businessUserInfo");
			value.created = element.LoadBool("created");
			value.deleted = element.LoadBool("deleted");
			value.email = element.LoadBool("email");
			value.id = element.LoadBool("id");
			value.name = element.LoadBool("name");
			value.photoLastUpdated = element.LoadBool("photoLastUpdated");
			value.photoUrl = element.LoadBool("photoUrl");
			value.privilege = element.LoadBool("privilege");
			value.serviceLevel = element.LoadBool("serviceLevel");
			value.shardId = element.LoadBool("shardId");
			value.timezone = element.LoadBool("timezone");
			value.updated = element.LoadBool("updated");
			value.username = element.LoadBool("username");

			return value;
		}

		private static Accounting LoadAccounting(this XmlElement parent, string name)
		{
			XmlElement element = parent.GetElement(name);
			if (element == null)
				return default(Accounting);
			if (element.GetAttribute("null") == "true")
				return default(Accounting);

			Accounting value = new Accounting();

			value.AvailablePoints = element.LoadInt32("AvailablePoints");
			value.BusinessId = element.LoadInt32("BusinessId");
			value.BusinessName = element.LoadString("BusinessName");
			value.BusinessRole = element.LoadEnum<BusinessUserRole>("BusinessRole");
			value.Currency = element.LoadString("Currency");
			value.LastFailedCharge = element.LoadInt64("LastFailedCharge");
			value.LastFailedChargeReason = element.LoadString("LastFailedChargeReason");
			value.LastRequestedCharge = element.LoadInt64("LastRequestedCharge");
			value.LastSuccessfulCharge = element.LoadInt64("LastSuccessfulCharge");
			value.NextChargeDate = element.LoadInt64("NextChargeDate");
			value.NextPaymentDue = element.LoadInt64("NextPaymentDue");
			value.PremiumCommerceService = element.LoadString("PremiumCommerceService");
			value.PremiumLockUntil = element.LoadInt64("PremiumLockUntil");
			value.PremiumOrderNumber = element.LoadString("PremiumOrderNumber");
			value.PremiumServiceSKU = element.LoadString("PremiumServiceSKU");
			value.PremiumServiceStart = element.LoadInt64("PremiumServiceStart");
			value.PremiumServiceStatus = element.LoadEnum<PremiumOrderStatus>("PremiumServiceStatus");
			value.PremiumSubscriptionNumber = element.LoadString("PremiumSubscriptionNumber");
			value.UnitDiscount = element.LoadInt32("UnitDiscount");
			value.UnitPrice = element.LoadInt32("UnitPrice");
			value.Updated = element.LoadInt64("Updated");
			value.UploadLimitEnd = element.LoadInt64("UploadLimitEnd");
			value.UploadLimitNextMonth = element.LoadInt64("UploadLimitNextMonth");
			value.__isset = element.LoadAccounting_Isset("__isset");

			return value;
		}

		private static Accounting.Isset LoadAccounting_Isset(this XmlElement parent, string name)
		{
			XmlElement element = parent.GetElement(name);
			if (element == null)
				return default(Accounting.Isset);

			Accounting.Isset value = new Accounting.Isset();

			value.availablePoints = element.LoadBool("availablePoints");
			value.businessId = element.LoadBool("businessId");
			value.businessName = element.LoadBool("businessName");
			value.businessRole = element.LoadBool("businessRole");
			value.currency = element.LoadBool("currency");
			value.lastFailedCharge = element.LoadBool("lastFailedCharge");
			value.lastFailedChargeReason = element.LoadBool("lastFailedChargeReason");
			value.lastRequestedCharge = element.LoadBool("lastRequestedCharge");
			value.lastSuccessfulCharge = element.LoadBool("lastSuccessfulCharge");
			value.nextChargeDate = element.LoadBool("nextChargeDate");
			value.nextPaymentDue = element.LoadBool("nextPaymentDue");
			value.premiumCommerceService = element.LoadBool("premiumCommerceService");
			value.premiumLockUntil = element.LoadBool("premiumLockUntil");
			value.premiumOrderNumber = element.LoadBool("premiumOrderNumber");
			value.premiumServiceSKU = element.LoadBool("premiumServiceSKU");
			value.premiumServiceStart = element.LoadBool("premiumServiceStart");
			value.premiumServiceStatus = element.LoadBool("premiumServiceStatus");
			value.premiumSubscriptionNumber = element.LoadBool("premiumSubscriptionNumber");
			value.unitDiscount = element.LoadBool("unitDiscount");
			value.unitPrice = element.LoadBool("unitPrice");
			value.updated = element.LoadBool("updated");
			value.uploadLimitEnd = element.LoadBool("uploadLimitEnd");
			value.uploadLimitNextMonth = element.LoadBool("uploadLimitNextMonth");

			return value;
		}

		private static AccountLimits LoadAccountLimits(this XmlElement parent, string name)
		{
			XmlElement element = parent.GetElement(name);
			if (element == null)
				return default(AccountLimits);
			if (element.GetAttribute("null") == "true")
				return default(AccountLimits);

			AccountLimits value = new AccountLimits();

			value.NoteResourceCountMax = element.LoadInt32("NoteResourceCountMax");
			value.NoteSizeMax = element.LoadInt64("NoteSizeMax");
			value.NoteTagCountMax = element.LoadInt32("NoteTagCountMax");
			value.ResourceSizeMax = element.LoadInt64("ResourceSizeMax");
			value.UploadLimit = element.LoadInt64("UploadLimit");
			value.UserLinkedNotebookMax = element.LoadInt32("UserLinkedNotebookMax");
			value.UserMailLimitDaily = element.LoadInt32("UserMailLimitDaily");
			value.UserNotebookCountMax = element.LoadInt32("UserNotebookCountMax");
			value.UserNoteCountMax = element.LoadInt32("UserNoteCountMax");
			value.UserSavedSearchesMax = element.LoadInt32("UserSavedSearchesMax");
			value.UserTagCountMax = element.LoadInt32("UserTagCountMax");
			value.__isset = element.LoadAccountLimits_Isset("__isset");

			return value;
		}

		private static AccountLimits.Isset LoadAccountLimits_Isset(this XmlElement parent, string name)
		{
			XmlElement element = parent.GetElement(name);
			if (element == null)
				return default(AccountLimits.Isset);

			AccountLimits.Isset value = new AccountLimits.Isset();

			value.noteResourceCountMax = element.LoadBool("noteResourceCountMax");
			value.noteSizeMax = element.LoadBool("noteSizeMax");
			value.noteTagCountMax = element.LoadBool("noteTagCountMax");
			value.resourceSizeMax = element.LoadBool("resourceSizeMax");
			value.uploadLimit = element.LoadBool("uploadLimit");
			value.userLinkedNotebookMax = element.LoadBool("userLinkedNotebookMax");
			value.userMailLimitDaily = element.LoadBool("userMailLimitDaily");
			value.userNotebookCountMax = element.LoadBool("userNotebookCountMax");
			value.userNoteCountMax = element.LoadBool("userNoteCountMax");
			value.userSavedSearchesMax = element.LoadBool("userSavedSearchesMax");
			value.userTagCountMax = element.LoadBool("userTagCountMax");

			return value;
		}

		private static UserAttributes LoadUserAttributes(this XmlElement parent, string name)
		{
			XmlElement element = parent.GetElement(name);
			if (element == null)
				return default(UserAttributes);
			if (element.GetAttribute("null") == "true")
				return default(UserAttributes);

			UserAttributes value = new UserAttributes();

			value.BusinessAddress = element.LoadString("BusinessAddress");
			value.ClipFullPage = element.LoadBool("ClipFullPage");
			value.Comments = element.LoadString("Comments");
			value.DailyEmailLimit = element.LoadInt32("DailyEmailLimit");
			value.DateAgreedToTermsOfService = element.LoadInt64("DateAgreedToTermsOfService");
			value.DefaultLatitude = element.LoadDouble("DefaultLatitude");
			value.DefaultLocationName = element.LoadString("DefaultLocationName");
			value.DefaultLongitude = element.LoadDouble("DefaultLongitude");
			value.EducationalDiscount = element.LoadBool("EducationalDiscount");
			value.EmailAddressLastConfirmed = element.LoadInt64("EmailAddressLastConfirmed");
			value.EmailOptOutDate = element.LoadInt64("EmailOptOutDate");
			value.GroupName = element.LoadString("GroupName");
			value.HideSponsorBilling = element.LoadBool("HideSponsorBilling");
			value.IncomingEmailAddress = element.LoadString("IncomingEmailAddress");
			value.MaxReferrals = element.LoadInt32("MaxReferrals");
			value.OptOutMachineLearning = element.LoadBool("OptOutMachineLearning");
			value.PartnerEmailOptInDate = element.LoadInt64("PartnerEmailOptInDate");
			value.PasswordUpdated = element.LoadInt64("PasswordUpdated");
			value.Preactivation = element.LoadBool("Preactivation");
			value.PreferredCountry = element.LoadString("PreferredCountry");
			value.PreferredLanguage = element.LoadString("PreferredLanguage");
			value.RecentMailedAddresses = element.LoadStringList("RecentMailedAddresses");
			value.RecognitionLanguage = element.LoadString("RecognitionLanguage");
			value.RefererCode = element.LoadString("RefererCode");
			value.ReferralCount = element.LoadInt32("ReferralCount");
			value.ReferralProof = element.LoadString("ReferralProof");
			value.ReminderEmailConfig = element.LoadEnum<ReminderEmailConfig>("ReminderEmailConfig");
			value.SalesforcePushEnabled = element.LoadBool("SalesforcePushEnabled");
			value.SentEmailCount = element.LoadInt32("SentEmailCount");
			value.SentEmailDate = element.LoadInt64("SentEmailDate");
			value.ShouldLogClientEvent = element.LoadBool("ShouldLogClientEvent");
			value.TwitterId = element.LoadString("TwitterId");
			value.TwitterUserName = element.LoadString("TwitterUserName");
			value.UseEmailAutoFiling = element.LoadBool("UseEmailAutoFiling");
			value.ViewedPromotions = element.LoadStringList("ViewedPromotions");
			value.__isset = element.LoadUserAttributes_Isset("__isset");

			return value;
		}

		private static UserAttributes.Isset LoadUserAttributes_Isset(this XmlElement parent, string name)
		{
			XmlElement element = parent.GetElement(name);
			if (element == null)
				return default(UserAttributes.Isset);

			UserAttributes.Isset value = new UserAttributes.Isset();

			value.businessAddress = element.LoadBool("businessAddress");
			value.clipFullPage = element.LoadBool("clipFullPage");
			value.comments = element.LoadBool("comments");
			value.dailyEmailLimit = element.LoadBool("dailyEmailLimit");
			value.dateAgreedToTermsOfService = element.LoadBool("dateAgreedToTermsOfService");
			value.defaultLatitude = element.LoadBool("defaultLatitude");
			value.defaultLocationName = element.LoadBool("defaultLocationName");
			value.defaultLongitude = element.LoadBool("defaultLongitude");
			value.educationalDiscount = element.LoadBool("educationalDiscount");
			value.emailAddressLastConfirmed = element.LoadBool("emailAddressLastConfirmed");
			value.emailOptOutDate = element.LoadBool("emailOptOutDate");
			value.groupName = element.LoadBool("groupName");
			value.hideSponsorBilling = element.LoadBool("hideSponsorBilling");
			value.incomingEmailAddress = element.LoadBool("incomingEmailAddress");
			value.maxReferrals = element.LoadBool("maxReferrals");
			value.optOutMachineLearning = element.LoadBool("optOutMachineLearning");
			value.partnerEmailOptInDate = element.LoadBool("partnerEmailOptInDate");
			value.passwordUpdated = element.LoadBool("passwordUpdated");
			value.preactivation = element.LoadBool("preactivation");
			value.preferredCountry = element.LoadBool("preferredCountry");
			value.preferredLanguage = element.LoadBool("preferredLanguage");
			value.recentMailedAddresses = element.LoadBool("recentMailedAddresses");
			value.recognitionLanguage = element.LoadBool("recognitionLanguage");
			value.refererCode = element.LoadBool("refererCode");
			value.referralCount = element.LoadBool("referralCount");
			value.referralProof = element.LoadBool("referralProof");
			value.reminderEmailConfig = element.LoadBool("reminderEmailConfig");
			value.salesforcePushEnabled = element.LoadBool("salesforcePushEnabled");
			value.sentEmailCount = element.LoadBool("sentEmailCount");
			value.sentEmailDate = element.LoadBool("sentEmailDate");
			value.shouldLogClientEvent = element.LoadBool("shouldLogClientEvent");
			value.twitterId = element.LoadBool("twitterId");
			value.twitterUserName = element.LoadBool("twitterUserName");
			value.useEmailAutoFiling = element.LoadBool("useEmailAutoFiling");
			value.viewedPromotions = element.LoadBool("viewedPromotions");

			return value;
		}

		private static BusinessUserInfo LoadBusinessUserInfo(this XmlElement parent, string name)
		{
			XmlElement element = parent.GetElement(name);
			if (element == null)
				return default(BusinessUserInfo);
			if (element.GetAttribute("null") == "true")
				return default(BusinessUserInfo);

			BusinessUserInfo value = new BusinessUserInfo();

			value.BusinessId = element.LoadInt32("BusinessId");
			value.BusinessName = element.LoadString("BusinessName");
			value.Email = element.LoadString("Email");
			value.Role = element.LoadEnum<BusinessUserRole>("Role");
			value.Updated = element.LoadInt64("Updated");
			value.__isset = element.LoadBusinessUserInfo_Isset("__isset");

			return value;
		}

		private static BusinessUserInfo.Isset LoadBusinessUserInfo_Isset(this XmlElement parent, string name)
		{
			XmlElement element = parent.GetElement(name);
			if (element == null)
				return default(BusinessUserInfo.Isset);

			BusinessUserInfo.Isset value = new BusinessUserInfo.Isset();

			value.businessId = element.LoadBool("businessId");
			value.businessName = element.LoadBool("businessName");
			value.email = element.LoadBool("email");
			value.role = element.LoadBool("role");
			value.updated = element.LoadBool("updated");

			return value;
		}

		private static LinkedNotebook LoadLinkedNotebook(this XmlElement element)
		{
			if (element == null)
				return default(LinkedNotebook);
			if (element.GetAttribute("null") == "true")
				return default(LinkedNotebook);

			LinkedNotebook value = new LinkedNotebook();

			value.BusinessId = element.LoadInt32("BusinessId");
			value.Guid = element.LoadString("Guid");
			value.NoteStoreUrl = element.LoadString("NoteStoreUrl");
			value.ShardId = element.LoadString("ShardId");
			value.SharedNotebookGlobalId = element.LoadString("SharedNotebookGlobalId");
			value.ShareName = element.LoadString("ShareName");
			value.Stack = element.LoadString("Stack");
			value.UpdateSequenceNum = element.LoadInt32("UpdateSequenceNum");
			value.Uri = element.LoadString("Uri");
			value.Username = element.LoadString("Username");
			value.WebApiUrlPrefix = element.LoadString("WebApiUrlPrefix");
			value.__isset = element.LoadLinkedNotebook_Isset("__isset");

			return value;
		}

		private static LinkedNotebook.Isset LoadLinkedNotebook_Isset(this XmlElement parent, string name)
		{
			XmlElement element = parent.GetElement(name);
			if (element == null)
				return default(LinkedNotebook.Isset);

			LinkedNotebook.Isset value = new LinkedNotebook.Isset();

			value.businessId = element.LoadBool("businessId");
			value.guid = element.LoadBool("guid");
			value.noteStoreUrl = element.LoadBool("noteStoreUrl");
			value.shardId = element.LoadBool("shardId");
			value.sharedNotebookGlobalId = element.LoadBool("sharedNotebookGlobalId");
			value.shareName = element.LoadBool("shareName");
			value.stack = element.LoadBool("stack");
			value.updateSequenceNum = element.LoadBool("updateSequenceNum");
			value.uri = element.LoadBool("uri");
			value.username = element.LoadBool("username");
			value.webApiUrlPrefix = element.LoadBool("webApiUrlPrefix");

			return value;
		}

		private static SharedNotebook LoadSharedNotebook(this XmlElement element)
		{
			if (element == null)
				return default(SharedNotebook);
			if (element.GetAttribute("null") == "true")
				return default(SharedNotebook);

			SharedNotebook value = new SharedNotebook();

			value.Email = element.LoadString("Email");
			value.GlobalId = element.LoadString("GlobalId");
			value.Id = element.LoadInt64("Id");
			value.NotebookGuid = element.LoadString("NotebookGuid");
			value.NotebookModifiable = element.LoadBool("NotebookModifiable");
			value.Privilege = element.LoadEnum<SharedNotebookPrivilegeLevel>("Privilege");
			value.RecipientIdentityId = element.LoadInt64("RecipientIdentityId");
			value.RecipientSettings = element.LoadSharedNotebookRecipientSettings("RecipientSettings");
			value.RecipientUserId = element.LoadInt32("RecipientUserId");
			value.RecipientUsername = element.LoadString("RecipientUsername");
			value.ServiceAssigned = element.LoadInt64("ServiceAssigned");
			value.ServiceCreated = element.LoadInt64("ServiceCreated");
			value.ServiceUpdated = element.LoadInt64("ServiceUpdated");
			value.SharerUserId = element.LoadInt32("SharerUserId");
			value.UserId = element.LoadInt32("UserId");
			value.Username = element.LoadString("Username");
			value.__isset = element.LoadSharedNotebook_Isset("__isset");

			return value;
		}

		private static SharedNotebook.Isset LoadSharedNotebook_Isset(this XmlElement parent, string name)
		{
			XmlElement element = parent.GetElement(name);
			if (element == null)
				return default(SharedNotebook.Isset);

			SharedNotebook.Isset value = new SharedNotebook.Isset();

			value.email = element.LoadBool("email");
			value.globalId = element.LoadBool("globalId");
			value.id = element.LoadBool("id");
			value.notebookGuid = element.LoadBool("notebookGuid");
			value.notebookModifiable = element.LoadBool("notebookModifiable");
			value.privilege = element.LoadBool("privilege");
			value.recipientIdentityId = element.LoadBool("recipientIdentityId");
			value.recipientSettings = element.LoadBool("recipientSettings");
			value.recipientUserId = element.LoadBool("recipientUserId");
			value.recipientUsername = element.LoadBool("recipientUsername");
			value.serviceAssigned = element.LoadBool("serviceAssigned");
			value.serviceCreated = element.LoadBool("serviceCreated");
			value.serviceUpdated = element.LoadBool("serviceUpdated");
			value.sharerUserId = element.LoadBool("sharerUserId");
			value.userId = element.LoadBool("userId");
			value.username = element.LoadBool("username");

			return value;
		}

		private static SharedNotebookRecipientSettings LoadSharedNotebookRecipientSettings(this XmlElement parent, string name)
		{
			XmlElement element = parent.GetElement(name);
			if (element == null)
				return default(SharedNotebookRecipientSettings);
			if (element.GetAttribute("null") == "true")
				return default(SharedNotebookRecipientSettings);

			SharedNotebookRecipientSettings value = new SharedNotebookRecipientSettings();

			value.ReminderNotifyEmail = element.LoadBool("ReminderNotifyEmail");
			value.ReminderNotifyInApp = element.LoadBool("ReminderNotifyInApp");
			value.__isset = element.LoadSharedNotebookRecipientSettings_Isset("__isset");

			return value;
		}

		private static SharedNotebookRecipientSettings.Isset LoadSharedNotebookRecipientSettings_Isset(this XmlElement parent, string name)
		{
			XmlElement element = parent.GetElement(name);
			if (element == null)
				return default(SharedNotebookRecipientSettings.Isset);

			SharedNotebookRecipientSettings.Isset value = new SharedNotebookRecipientSettings.Isset();

			value.reminderNotifyEmail = element.LoadBool("reminderNotifyEmail");
			value.reminderNotifyInApp = element.LoadBool("reminderNotifyInApp");

			return value;
		}

		private static XmlElement GetElement(this XmlElement parent, string name)
        {
			return parent.SelectSingleNode(name) as XmlElement;
        }
	}
}
