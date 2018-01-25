using BitCurb.CodeSamples.Core;

namespace BitCurb.CodeSamples.Filters
{
    public class FilterCsvParser : CsvParser<MobilePhone>
    {
        public FilterCsvParser(string file) : base(file)
        {
        }

        public override MobilePhone ParseItem(string[] fields, string[] fieldNames)
        {
            MobilePhone phone = new MobilePhone();

            for (int i = 0; i < fieldNames.Length; i++)
            {
                string fieldName = fieldNames[i];
                string fieldValue = fields[i];

                switch (fieldName)
                {
                    case "DeviceName":
                        phone.DeviceName = fieldValue;
                        break;
                    case "Brand":
                        phone.Brand = fieldValue;
                        break;
                    case "technology":
                        phone.Technology = fieldValue;
                        break;
                    case "gprs":
                        phone.Gprs = fieldValue;
                        break;
                    case "edge":
                        phone.Edge = fieldValue;
                        break;
                    case "announced":
                        phone.Announced = fieldValue;
                        break;
                    case "status":
                        phone.Status = fieldValue;
                        break;
                    case "dimensions":
                        phone.Dimensions = fieldValue;
                        break;
                    case "weight":
                        phone.Weight = fieldValue;
                        break;
                    case "sim":
                        phone.Sim = fieldValue;
                        break;
                    case "type":
                        phone.Type = fieldValue;
                        break;
                    case "size":
                        phone.Size = fieldValue;
                        break;
                    case "resolution":
                        phone.Resolution = fieldValue;
                        break;
                    case "display_c":
                        phone.DisplayC = fieldValue;
                        break;
                    case "card_slot":
                        phone.CardSlot = fieldValue;
                        break;
                    case "alert_types":
                        phone.AlertTypes = fieldValue;
                        break;
                    case "loudspeaker_":
                        phone.Loudspeaker1 = fieldValue;
                        break;
                    case "wlan":
                        phone.Wlan = fieldValue;
                        break;
                    case "bluetooth":
                        phone.Bluetooth = fieldValue;
                        break;
                    case "gps":
                        phone.Gps = fieldValue;
                        break;
                    case "radio":
                        phone.Radio = fieldValue;
                        break;
                    case "usb":
                        phone.Usb = fieldValue;
                        break;
                    case "messaging":
                        phone.Messaging = fieldValue;
                        break;
                    case "browser":
                        phone.Browser = fieldValue;
                        break;
                    case "java":
                        phone.Java = fieldValue;
                        break;
                    case "features_c":
                        phone.FeaturesC = fieldValue;
                        break;
                    case "battery_c":
                        phone.BatteryC = fieldValue;
                        break;
                    case "stand_by_hours":
                        phone.StandByHours = fieldValue;
                        break;
                    case "talk_time_hours":
                        phone.TalkTimeHours = fieldValue;
                        break;
                    case "colors":
                        phone.Colors = fieldValue;
                        break;
                    case "sar_eu":
                        phone.SarEu = fieldValue;
                        break;
                    case "cpu":
                        phone.Cpu = fieldValue;
                        break;
                    case "internal_memory_mb":
                        phone.InternalMemory = fieldValue;
                        break;
                    case "os":
                        phone.OS = fieldValue;
                        break;
                    case "primary_camera_mp":
                        phone.PrimaryCamera = fieldValue;
                        break;
                    case "video":
                        phone.Video = fieldValue;
                        break;
                    case "secondary":
                        phone.Secondary = fieldValue;
                        break;
                    case "speed":
                        phone.Speed = fieldValue;
                        break;
                    case "_2g_bands":
                        phone.TwoGBands = fieldValue;
                        break;
                    case "_3_5mm_jack_":
                        phone.ThreeFiveMmJack = fieldValue;
                        break;
                    case "_3g_bands":
                        phone.ThreeGBands = fieldValue;
                        break;
                    case "sar_us":
                        phone.SarUs = fieldValue;
                        break;
                    case "sensors":
                        phone.Sensors = fieldValue;
                        break;
                    case "network_c":
                        phone.NetworkC = fieldValue;
                        break;
                    case "keyboard":
                        phone.Keyboard = fieldValue;
                        break;
                    case "chipset":
                        phone.Chipset = fieldValue;
                        break;
                    case "features":
                        phone.Features = fieldValue;
                        break;
                    case "gpu":
                        phone.Gpu = fieldValue;
                        break;
                    case "loudspeaker":
                        phone.Loudspeaker2 = fieldValue;
                        break;
                    case "audio_quality":
                        phone.AudioQuality = fieldValue;
                        break;
                    case "camera":
                        phone.Camera = fieldValue;
                        break;
                    case "sound_c":
                        phone.SoundC = fieldValue;
                        break;
                    case "multitouch":
                        phone.Multitouch = fieldValue;
                        break;
                    case "body_c":
                        phone.BodyC = fieldValue;
                        break;
                    case "protection":
                        phone.Protection = fieldValue;
                        break;
                    case "phonebook":
                        phone.Phonebook = fieldValue;
                        break;
                    case "call_records":
                        phone.CallRecords = fieldValue;
                        break;
                    case "games":
                        phone.Games = fieldValue;
                        break;
                    case "nfc":
                        phone.Nfc = fieldValue;
                        break;
                    case "display":
                        phone.Display = fieldValue;
                        break;
                    case "_4g_bands":
                        phone.FourGBands = fieldValue;
                        break;
                    case "music_play":
                        phone.MusicPlay = fieldValue;
                        break;
                    case "performance":
                        phone.Performance = fieldValue;
                        break;
                }
            }

            return phone;
        }
    }
}
