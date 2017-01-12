using UnityEngine;
using System.Collections;
using System.Xml;


using System.Collections.Generic; //Needed for Lists


using System.Xml.Serialization; //Needed for XML Functionality

using System.IO;

using System.Xml.Linq; //Needed for XDocument

public class readXml : MonoBehaviour {
	XDocument xmlDoc;
	XDocument DictDoc;
	public int DictCount = 0;
	public int ElementCount = 0;
	public List<Dict> Dicts;

	public void initiate (){
		Dicts = new List<Dict> ();
		List<Key> Keys;
		xmlDoc = XDocument.Load( "Assets/Resources/Sequences/firstSequence.xml" );

		if (xmlDoc == null) {
			Debug.Log (" Xml Null");
		} else {
			var doc = xmlDoc.Root;
			var dicts = doc.Elements("dict");
			foreach (var dict in dicts)
			{
				Keys = new List<Key> ();
				var elementsInDict = dict.Elements ();

				ArrayList listKey = new ArrayList ();
				List<XElement> listValue = new List<XElement>();
				foreach (var elementInDict in elementsInDict){
					if (elementInDict.Name == "key") {
						listKey.Add (elementInDict.Value);
					}
					else {
						listValue.Add (elementInDict);
					}
				}
				for (int i = 0; i < listKey.Count; i++)
				{
					switch ((string)listKey[i])
					{
					case "Name":
						Keys.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.NAME));
						break;
					case "Type":
						Keys.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.TYPE));
						break;
					case "Parameters":
						Keys.Add(new Key((string)listKey[i],listValue[i], KeyType.PARAMETERS));
						break;
					case "Duration":
						Keys.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.DURATION));
						break;
					}
				}	
				Dicts.Add (new Dict (Keys));
			}
		}
	}

	public List<Dict> getDicts (){
		return this.Dicts;
	}

	public Dict getDict(int dictNumber){
		return this.Dicts [dictNumber];
	}

	public List<Key> getParametersForDict(int dictNumber){
		return this.Dicts [dictNumber].InDict.Keys;
	}

	public List<Key> getKeyForDict (int dictNumber) {
		return this.Dicts [dictNumber].Keys;
	}

	public string getTypeOfDict (int dictNumber){
		string res = "";
		List<Key> keys = getKeyForDict (dictNumber);
		foreach (Key key in keys) {
			if (key.Name.ToString () == "Type") {
				res = key.Value.ToString ();
			}
		}
		return res;
	}

	public string getNameOfDict (int dictNumber){
		string res = "";
		List<Key> keys = getKeyForDict (dictNumber);
		foreach (Key key in keys) {
			if (key.Name.ToString () == "Name") {
				res = key.Value.ToString();
			}
		}
		return res;
	}

	public int getDurationOfDict (int dictNumber){
		int res = 0;
		List<Key> keys = getKeyForDict (dictNumber);
		foreach (Key key in keys) {
			if (key.Name.ToString () == "Duration") {
				res = (int)key.Value;
			}
		}
		return res;
	}

	public int getNumberOfButtonsOfDict (int dictNumber){
		int res = 0;
		if (getTypeOfDict (dictNumber) == "button") {

			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "Number of buttons") {
					res = int.Parse(key.Value.ToString());
				}
			}
		} else {
			Debug.Log ("Ce dict n'est pas de type Button !");
			return 0;
		}
		return res;
	}

	public string getImageFileNameForButtonOfDict (int dictNumber, int buttonNumber){
		string res = "";
		if (getTypeOfDict (dictNumber) == "button") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "Image filename for button") {
					if (key.IdObject == buttonNumber) {
						res = key.Value.ToString();
					}
				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Button !");
			return null;
		}
		return res;
	}



	public int getNextEventIndexForButtonOfDict (int dictNumber, int buttonNumber){
		int res = 0;
		if (getTypeOfDict (dictNumber) == "button") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "Next event index for button") {
					if (key.IdObject == buttonNumber) {
						res =int.Parse( (string) key.Value );
					}
				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Button !");
			return 0;
		}
		return res;
	}

	public float getXPositionForButtonOfDict (int dictNumber, int buttonNumber){
		float res = 0f;
		if (getTypeOfDict (dictNumber) == "button") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "X position for button") {
					if (key.IdObject == buttonNumber) {
						res =float.Parse( (string) key.Value );
					}
				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Button !");
			return 0f;
		}
		return res;
	}

	public float getYPositionForButtonOfDict (int dictNumber, int buttonNumber){
		float res = 0f;
		if (getTypeOfDict (dictNumber) == "button") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "Y position for button") {
					if (key.IdObject == buttonNumber) {
						res =float.Parse( (string) key.Value );
					}
				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Button !");
			return 0f;
		}
		return res;
	}

	public string getSoundFileSoundOfDict (int dictNumber){
		string res = "";
		if (getTypeOfDict (dictNumber) == "son") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "Sound file") {
					res = key.Value.ToString();

				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Son !");
			return "";
		}
		return res;
	}

	public string getImageFileImageOfDict (int dictNumber){
		string res = "";
		if (getTypeOfDict (dictNumber) == "image") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "Image file") {
					res = key.Value.ToString();

				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Image !");
			return "";
		}
		return res;
	}

	public float getPositionXImageOfDict (int dictNumber){
		float res = 0f;
		if (getTypeOfDict (dictNumber) == "image") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "Position X") {
					res =float.Parse( (string) key.Value );

				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Image !");
			return 0f;
		}
		return res;
	}

	public float getPositionYImageOfDict (int dictNumber){
		float res = 0f;
		if (getTypeOfDict (dictNumber) == "image") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "Position Y") {
					res =float.Parse( (string) key.Value );

				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Image !");
			return 0f;
		}
		return res;
	}

	public int getNumberOfImagesAnimationOfDict (int dictNumber){
		int res = 0;
		if (getTypeOfDict (dictNumber) == "animation") {

			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "Number of images") {
					res =int.Parse( (string) key.Value );
				}
			}
		} else {
			Debug.Log ("Ce dict n'est pas de type animation !");
			return 0;
		}
		return res;
	}

	public string getFileNameForImagesAnimationOfDict (int dictNumber){
		string res = "";
		if (getTypeOfDict (dictNumber) == "animation") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "Filename for images") {
					res = key.Value.ToString();

				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Animation !");
			return "";
		}
		return res;
	}

	public float getAnimationLocationXAnimationOfDict (int dictNumber){
		float res = 0f;
		if (getTypeOfDict (dictNumber) == "animation") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "Animation location X") {
					res =float.Parse( (string) key.Value );

				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Animation !");
			return 0f;
		}
		return res;
	}

	public float getAnimationLocationYAnimationOfDict (int dictNumber){
		float res = 0f;
		if (getTypeOfDict (dictNumber) == "animation") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "Animation location Y") {
					res =float.Parse( (string) key.Value );

				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Animation !");
			return 0f;
		}
		return res;
	}

	public int getNumberOfRepeatsAnimationOfDict (int dictNumber){
		int res = 0;
		if (getTypeOfDict (dictNumber) == "animation") {

			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "Number of repeats") {
					res =int.Parse( (string) key.Value );
				}
			}
		} else {
			Debug.Log ("Ce dict n'est pas de type animation !");
			return 0;
		}
		return res;
	}

	public int getAnimationDurationAnimationOfDict (int dictNumber){
		int res = 0;
		if (getTypeOfDict (dictNumber) == "animation") {

			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "Animation duration") {
					res =int.Parse( (string) key.Value );
				}
			}
		} else {
			Debug.Log ("Ce dict n'est pas de type animation !");
			return 0;
		}
		return res;
	}

	public float getScaleXAnimationOfDict (int dictNumber){
		float res = 0f;
		if (getTypeOfDict (dictNumber) == "animation") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "Scale X") {
					res =float.Parse( (string) key.Value );

				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Animation !");
			return 0f;
		}
		return res;
	}

	public float getScaleYAnimationOfDict (int dictNumber){
		float res = 0f;
		if (getTypeOfDict (dictNumber) == "animation") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "Scale Y") {
					res =float.Parse( (string) key.Value );

				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Animation !");
			return 0f;
		}
		return res;
	}

	public float getMovementDurationAnimationOfDict (int dictNumber){
		float res = 0f;
		if (getTypeOfDict (dictNumber) == "animation") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "Movement duration") {
					res =float.Parse( (string) key.Value );

				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Animation !");
			return 0f;
		}
		return res;
	}

	public float getTranslationXAnimationOfDict (int dictNumber){
		float res = 0f;
		if (getTypeOfDict (dictNumber) == "animation") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "Translation X") {
					res =float.Parse( (string) key.Value );

				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Animation !");
			return 0f;
		}
		return res;
	}

	public float getTranslationYAnimationOfDict (int dictNumber){
		float res = 0f;
		if (getTypeOfDict (dictNumber) == "animation") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "Translation Y") {
					res =float.Parse( (string) key.Value );

				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Animation !");
			return 0f;
		}
		return res;
	}

	public float getTranslationZAnimationOfDict (int dictNumber){
		float res = 0f;
		if (getTypeOfDict (dictNumber) == "animation") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "Translation Z") {
					res =float.Parse( (string) key.Value );

				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Animation !");
			return 0f;
		}
		return res;
	}

	public float getXLocationAnimatedTextOfDict (int dictNumber){
		float res = 0f;
		if (getTypeOfDict (dictNumber) == "animated text") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "x location") {
					res =float.Parse( (string) key.Value );

				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Animated Text !");
			return 0f;
		}
		return res;
	}

	public float getYLocationAnimatedTextOfDict (int dictNumber){
		float res = 0f;
		if (getTypeOfDict (dictNumber) == "animated text") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "y location") {
					res =float.Parse( (string) key.Value );

				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Animated Text !");
			return 0f;
		}
		return res;
	}

	public float getHeightAnimatedTextOfDict (int dictNumber){
		float res = 0f;
		if (getTypeOfDict (dictNumber) == "animated text") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "height") {
					res =float.Parse( (string) key.Value );

				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Animated Text !");
			return 0f;
		}
		return res;
	}

	public float getWidthAnimatedTextOfDict (int dictNumber){
		float res = 0f;
		if (getTypeOfDict (dictNumber) == "animated text") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "width") {
					res =float.Parse( (string) key.Value );

				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Animated Text !");
			return 0f;
		}
		return res;
	}

	public string getDisplayedTextAnimatedTextOfDict (int dictNumber){
		string res = "";
		if (getTypeOfDict (dictNumber) == "animated text") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "displayed text") {
					res = key.Value.ToString();

				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Animated Text !");
			return "";
		}
		return res;
	}

	public float getTextSpeedAnimatedTextOfDict (int dictNumber){
		float res = 0f;
		if (getTypeOfDict (dictNumber) == "animated text") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "text speed") {
					res =float.Parse( (string) key.Value );

				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Animated Text !");
			return 0f;
		}
		return res;
	}

	public int getScaleFactorXCameraOfDict (int dictNumber){
		int res = 0;
		if (getTypeOfDict (dictNumber) == "camera") {

			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "Scale factor X") {
					res =int.Parse( (string) key.Value );
				}
			}
		} else {
			Debug.Log ("Ce dict n'est pas de type Camera !");
			return 0;
		}
		return res;
	}

	public int getScaleFactorYCameraOfDict (int dictNumber){
		int res = 0;
		if (getTypeOfDict (dictNumber) == "camera") {

			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "Scale factor Y") {
					res =int.Parse( (string) key.Value );
				}
			}
		} else {
			Debug.Log ("Ce dict n'est pas de type Camera !");
			return 0;
		}
		return res;
	}

	public string getOverlayImageFileCameraOfDict (int dictNumber){
		string res = "";
		if (getTypeOfDict (dictNumber) == "camera") {
			List<Key> keys = getParametersForDict (dictNumber);
			foreach (Key key in keys) {
				if (key.Name.ToString () == "Overlay image file") {
					res = key.Value.ToString();

				}
			}
		}
		else {
			Debug.Log ("Ce dict n'est pas de type Camera !");
			return "";
		}
		return res;
	}

}





public class Dict
{
	public List<Key> Keys { get; set; }
	public InDict InDict { get; set;}
	public Dict(List<Key> keys)
	{
		Keys = keys;
		List<Key> KeysInDict;
		foreach (Key key in Keys) {
			KeysInDict = new List<Key> ();
			if (key.Type == KeyType.PARAMETERS) {
				string param = key.Value.ToString ();
				XDocument xml = XDocument.Parse( param );
				var xelements = xml.Elements ("dict");
				var test = xelements.Elements ();
				ArrayList listKey = new ArrayList ();
				List<XElement> listValue = new List<XElement>();
				foreach (var element in test) {

					if (element.Name == "key") {
						listKey.Add (element.Value);
					}
					else {
						listValue.Add (element);
					}	
				}
				for (int i = 0; i < listKey.Count; i++)
				{
					string lastforchar = (string) listKey [i];
					char last = (char)lastforchar [lastforchar.Length - 1];
					if ((string)listKey[i] == "Number of buttons") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.NUMBER_OF_BUTTONS));
					}
					if ((string)listKey[i] == "Image filename for button " + last) {
						KeysInDict.Add(new Key("Image filename for button",listValue[i].Value, KeyType.IMAGE_FILENAME_FOR_BUTTON,(int)char.GetNumericValue(last)));
					}
					if ( (string)listKey[i] == "Next event index for button " + last) {
						KeysInDict.Add(new Key("Next event index for button",listValue[i].Value, KeyType.NEXT_EVENT_INDEX_FOR_BUTTON, (int)char.GetNumericValue(last)));
					}
					if ( (string)listKey[i] == "X position for button " + last) {
						KeysInDict.Add(new Key("X position for button",listValue[i].Value, KeyType.X_POSITION_FOR_BUTTON, (int)char.GetNumericValue(last)));
					}
					if ( (string)listKey[i] == "Y position for button " + last) {
						KeysInDict.Add(new Key("Y position for button",listValue[i].Value, KeyType.Y_POSITION_FOR_BUTTON, (int)char.GetNumericValue(last)));
					}
					if ((string)listKey[i] == "Name") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.NAME));
					}
					if ((string)listKey[i] == "Type") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.TYPE));
					}
					if ((string)listKey[i] == "Parameters") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.PARAMETERS));
					}
					if ((string)listKey[i] == "Duration") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.DURATION));
					}
					if ((string)listKey[i] == "Sound file") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.SOUND_FILE));
					}
					if ((string)listKey[i] == "Image file") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.IMAGE_FILE));
					}
					if ((string)listKey[i] == "Position X") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.POSITION_X));
					}
					if ((string)listKey[i] == "Position Y") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.POSITION_Y));
					}
					if ((string)listKey[i] == "Movement") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.MOVEMENT));
					}
					if ((string)listKey[i] == "Number of images") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.NUMBER_OF_IMAGES));
					}
					if ((string)listKey[i] == "Filename for images") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.FILENAME_FOR_IMAGES));
					}
					if ((string)listKey[i] == "Animation location X") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.ANIMATION_LOCATION_X));
					}
					if ((string)listKey[i] == "Animation location Y") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.ANIMATION_LOCATION_Y));
					}
					if ((string)listKey[i] == "Number of repeats") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.NUMBER_OF_REPEATS));
					}
					if ((string)listKey[i] == "Animation duration") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.ANIMATION_DURATION));
					}
					if ((string)listKey[i] == "Scale X") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.SCALE_X));
					}
					if ((string)listKey[i] == "Scale Y") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.SCALE_Y));
					}
					if ((string)listKey[i] == "x location") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.X_LOCATION));
					}
					if ((string)listKey[i] == "y location") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.Y_LOCATION));
					}
					if ((string)listKey[i] == "height") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.HEIGHT));
					}
					if ((string)listKey[i] == "width") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.WIDTH));
					}
					if ((string)listKey[i] == "displayed text") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.DISPLAYED_TEXT));
					}
					if ((string)listKey[i] == "text speed") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.TEXT_SPEED));
					}
					if ((string)listKey[i] == "Display off") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.DISPLAY_OFF));
					}
					if ((string)listKey[i] == "Off") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.OFF));
					}
					if ((string)listKey[i] == "On or off") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.ON_OR_OFF));
					}
					if ((string)listKey[i] == "Rear or front") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.REAR_OR_FRONT));
					}
					if ((string)listKey[i] == "Scale factor X") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.SCALE_FACTOR_X));
					}
					if ((string)listKey[i] == "Scale factor Y") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.SCALE_FACTOR_Y));
					}
					if ((string)listKey[i] == "Overlay image file") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.OVERLAY_IMAGE_FILE));
					}
					if ((string)listKey[i] == "Movement ?") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.MOVEMENT));
					}
					if ((string)listKey[i] == "false parameter") {
						KeysInDict.Add(new Key((string)listKey[i],listValue[i].Value, KeyType.FALSE_PARAMETER));
					}
				}	

				InDict = new InDict(KeysInDict);

			}
		}
	}
	public Dict (){
	}
}

public class InDict
{
	public List<Key> Keys { get; set; }

	public InDict(List<Key> keys)
	{
		Keys = keys;
	}
	public InDict (){
	}
}

public class Key {
	public string Name { get; set; }
	public object Value { get; set; }
	public int IdObject { get; set; }
	public KeyType Type { get; set; }

	public Key (){}
	public Key (object value){
		Value = value;
	}
	public Key (KeyType type){
		Type = type;
	}
	public Key (string name, object value, KeyType type){
		Name = name;
		Value = value;
		Type = type;
	}
	public Key (string name, object value, KeyType type, int idObject){
		Name = name;
		Value = value;
		Type = type;
		IdObject = idObject;
	}
}

public enum KeyType {
	NAME,
	TYPE,
	PARAMETERS,
	DURATION,
	NUMBER_OF_BUTTONS,
	IMAGE_FILENAME_FOR_BUTTON,
	NEXT_EVENT_INDEX_FOR_BUTTON,
	X_POSITION_FOR_BUTTON,
	Y_POSITION_FOR_BUTTON,
	SOUND_FILE,
	IMAGE_FILE,
	POSITION_X,
	POSITION_Y,
	NUMBER_OF_IMAGES,
	FILENAME_FOR_IMAGES,
	ANIMATION_LOCATION_X,
	ANIMATION_LOCATION_Y,
	NUMBER_OF_REPEATS,
	ANIMATION_DURATION,
	SCALE_X,
	SCALE_Y,
	X_LOCATION,
	Y_LOCATION,
	HEIGHT,
	WIDTH,
	DISPLAYED_TEXT,
	TEXT_SPEED,
	DISPLAY_OFF,
	OFF,
	ON_OR_OFF,
	REAR_OR_FRONT,
	SCALE_FACTOR_X,
	SCALE_FACTOR_Y,
	OVERLAY_IMAGE_FILE,
	MOVEMENT,
	FALSE_PARAMETER
}
