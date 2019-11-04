using System;
using System.Data;
using USC.GISResearchLab.Common.Addresses.AbstractClasses;
using USC.GISResearchLab.Geocoding.Core.OutputData;


namespace USC.GISResearchLab.Geocoding.Core.Metadata.Qualities
{

    // this was moved to Geocoding.Core.Metadata.Qualities.Naaccr.Types project instead of having it here.

    //public enum NAACCRGISCoordinateQualityType
    //{
    //    Unknown,
    //    AddressPoint,
    //    GPS,
    //    Parcel,
    //    StreetSegmentInterpolation,
    //    StreetIntersection,
    //    StreetCentroid,
    //    AddressZIPPlus4Centroid,
    //    AddressZIPPlus2Centroid,
    //    ManualLookup,
    //    AddressZIPCentroid,
    //    POBoxZIPCentroid,
    //    CityCentroid,
    //    CountyCentroid,
    //    Unmatchable,
    //    Missing
    //}

    public class NAACCRGISCoordinateQualityConverter
    {


        public const string NAACCR_GIS_COORDINATE_QUALITY_NAME_ADDRESS_POINT = "QUALITY_ADDRESS_POINT";
        public const string NAACCR_GIS_COORDINATE_QUALITY_NAME_GPS = "QUALITY_GPS";
        public const string NAACCR_GIS_COORDINATE_QUALITY_NAME_PARCEL_CENTROID = "QUALITY_PARCEL_CENTROID";
        public const string NAACCR_GIS_COORDINATE_QUALITY_NAME_STREET_SEGMENT_INTERPOLATION = "QUALITY_STREET_SEGMENT_INTERPOLATION";
        public const string NAACCR_GIS_COORDINATE_QUALITY_NAME_STREET_INTERSECTION = "QUALITY_STREET_INTERSECTION";
        public const string NAACCR_GIS_COORDINATE_QUALITY_NAME_STREET_CENTROID = "QUALITY_STREET_CENTROID";
        public const string NAACCR_GIS_COORDINATE_QUALITY_NAME_ADDRESS_ZIP_CODE_PLUS_4_CENTROID = "QUALITY_ZIP_CODE_PLUS_4_CENTROID";
        public const string NAACCR_GIS_COORDINATE_QUALITY_NAME_ADDRESS_ZIP_CODE_PLUS_2_CENTROID = "QUALITY_ZIP_CODE_PLUS_2_CENTROID";
        public const string NAACCR_GIS_COORDINATE_QUALITY_NAME_MANUAL_LOOKUP = "QUALITY_MANUAL_LOOKUP";
        public const string NAACCR_GIS_COORDINATE_QUALITY_NAME_ADDRESS_ZIP_CODE_AREA_CENTROID = "QUALITY_ZIP_CODE_CENTROID";
        public const string NAACCR_GIS_COORDINATE_QUALITY_NAME_PO_BOX_ZIP_CODE_CENTROID = "QUALITY_PO_BOX_ZIP_CODE_CENTROID";
        public const string NAACCR_GIS_COORDINATE_QUALITY_NAME_CITY_CENTROID = "QUALITY_CITY_CENTROID";
        public const string NAACCR_GIS_COORDINATE_QUALITY_NAME_COUNTY_CENTROID = "QUALITY_COUNTY_CENTROID";
        public const string NAACCR_GIS_COORDINATE_QUALITY_NAME_UNKNOWN = "QUALITY_UNKNOWN";
        public const string NAACCR_GIS_COORDINATE_QUALITY_NAME_UNMATCHABLE = "QUALITY_UNMATCHABLE";
        public const string NAACCR_GIS_COORDINATE_QUALITY_NAME_MISSING = "QUALITY_MISSING";

        public const string NAACCR_GIS_COORDINATE_QUALITY_CODE_ADDRESS_POINT = "00";
        public const string NAACCR_GIS_COORDINATE_QUALITY_CODE_GPS = "01";
        public const string NAACCR_GIS_COORDINATE_QUALITY_CODE_PARCEL_CENTROID = "02";
        public const string NAACCR_GIS_COORDINATE_QUALITY_CODE_STREET_SEGMENT_INTERPOLATION = "03";
        public const string NAACCR_GIS_COORDINATE_QUALITY_CODE_STREET_INTERSECTION = "04";
        public const string NAACCR_GIS_COORDINATE_QUALITY_CODE_STREET_CENTROID = "05";
        public const string NAACCR_GIS_COORDINATE_QUALITY_CODE_ADDRESS_ZIP_CODE_PLUS_4_CENTROID = "06";
        public const string NAACCR_GIS_COORDINATE_QUALITY_CODE_ADDRESS_ZIP_CODE_PLUS_2_CENTROID = "07";
        public const string NAACCR_GIS_COORDINATE_QUALITY_CODE_MANUAL_LOOKUP = "08";
        public const string NAACCR_GIS_COORDINATE_QUALITY_CODE_ADDRESS_ZIP_CODE_AREA_CENTROID = "09";
        public const string NAACCR_GIS_COORDINATE_QUALITY_CODE_PO_BOX_ZIP_CODE_CENTROID = "10";
        public const string NAACCR_GIS_COORDINATE_QUALITY_CODE_CITY_CENTROID = "11";
        public const string NAACCR_GIS_COORDINATE_QUALITY_CODE_COUNTY_CENTROID = "12";
        public const string NAACCR_GIS_COORDINATE_QUALITY_CODE_UNKNOWN = "98";
        public const string NAACCR_GIS_COORDINATE_QUALITY_CODE_UNMATCHABLE = "99";
        public const string NAACCR_GIS_COORDINATE_QUALITY_CODE_MISSING = "";

        public const string NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_ADDRESS_POINT = "addr point";
        public const string NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_GPS = "gps";
        public const string NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_PARCEL_CENTROID = "parcel";
        public const string NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_STREET_SEGMENT_INTERPOLATION = "street interp";
        public const string NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_STREET_INTERSECTION = "street inter";
        public const string NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_STREET_CENTROID = "street centrd";
        public const string NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_ADDRESS_ZIP_CODE_PLUS_4_CENTROID = "addr zip+4";
        public const string NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_ADDRESS_ZIP_CODE_PLUS_2_CENTROID = "addr zip+2";
        public const string NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_MANUAL_LOOKUP = "manual";
        public const string NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_ADDRESS_ZIP_CODE_AREA_CENTROID = "addr zip";
        public const string NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_PO_BOX_ZIP_CODE_CENTROID = "pobox zip";
        public const string NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_CITY_CENTROID = "city";
        public const string NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_COUNTY_CENTROID = "county";
        public const string NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_UNKNOWN = "unknown";
        public const string NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_UNMATCHABLE = "unmatchable";
        public const string NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_MISSING = "missing";


        public const string NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_ADDRESS_POINT = "Coordinates derived from local government-maintained address points, which are based on property parcel locations, not interpolation over a street segment’s address range";
        public const string NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_GPS = "Coordinates assigned by Global Positioning System (GPS)";
        public const string NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_PARCEL_CENTROID = "Coordinates are match of house number and street, and based on property parcel location";
        public const string NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_STREET_SEGMENT_INTERPOLATION = "Coordinates are match of house number and street, interpolated over the matching street segment’s address range";
        public const string NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_STREET_INTERSECTION = "Coordinates are street intersections";
        public const string NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_STREET_CENTROID = "Coordinates are at mid-point of street segment (missing or invalid building number)";
        public const string NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_ADDRESS_ZIP_CODE_PLUS_4_CENTROID = "Coordinates are address ZIP code+4 centroid";
        public const string NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_ADDRESS_ZIP_CODE_PLUS_2_CENTROID = "Coordinates are address ZIP code+2 centroid";
        public const string NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_MANUAL_LOOKUP = "Coordinates were obtained manually by looking up a location on a paper or electronic map";
        public const string NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_ADDRESS_ZIP_CODE_AREA_CENTROID = "Coordinates are address 5-digit ZIP code centroid";
        public const string NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_PO_BOX_ZIP_CODE_CENTROID = "Coordinates are point ZIP code of Post Office Box or Rural Route";
        public const string NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_CITY_CENTROID = "Coordinates are centroid of address city (when address ZIP code is unknown or invalid, and there are multiple ZIP codes for the city)";
        public const string NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_COUNTY_CENTROID = "Coordinates are centroid of county";
        public const string NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_UNKNOWN = "Latitude and longitude are assigned, but coordinate quality is unknown";
        public const string NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_UNMATCHABLE = "Latitude and longitude are not assigned, but geocoding was attempted; unable to assign coordinates based on available information";
        public const string NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_MISSING = "GIS Coordinate Quality not coded";



        public static DataTable GetAllQualities()
        {
            DataTable ret = new DataTable();
            ret.Columns.Add(new DataColumn("id", typeof(int)));
            ret.Columns.Add(new DataColumn("code", typeof(string)));
            ret.Columns.Add(new DataColumn("name", typeof(string)));
            ret.Columns.Add(new DataColumn("description", typeof(string)));
            ret.Columns.Add(new DataColumn("value", typeof(string)));

            //DataRow row = null;

            foreach (NAACCRGISCoordinateQualityType item in Enum.GetValues(typeof(NAACCRGISCoordinateQualityType)))
            {
                DataRow row = ret.NewRow();
                row["id"] = (int)item;
                row["code"] = GetNAACCRGISCoordinateQualityCode(item);
                row["name"] = GetNAACCRGISCoordinateQualityName(item);
                row["description"] = GetNAACCRGISCoordinateQualityDescription(item);
                row["value"] = item.ToString();
                ret.Rows.Add(row);
            }


            return ret;
        }

        public static NAACCRGISCoordinateQualityType GetNAACCRGISCoordinateQualityTypeForGeocode(IGeocode geocode)
        {
            NAACCRGISCoordinateQualityType ret = NAACCRGISCoordinateQualityType.Unknown;

            GeocodeQualityType geocodeQualityType = geocode.GeocodeQualityType;

            if (geocode.InputAddress != null)
            {
                AddressLocationTypes addressLocationTypes = geocode.InputAddress.AddressLocationType;

                if (addressLocationTypes != AddressLocationTypes.Unknown)
                {
                    switch (geocodeQualityType)
                    {
                        case GeocodeQualityType.ActualLotInterpolation:
                            ret = NAACCRGISCoordinateQualityType.StreetSegmentInterpolation;
                            break;
                        case GeocodeQualityType.AddressRangeInterpolation:
                            ret = NAACCRGISCoordinateQualityType.StreetSegmentInterpolation;
                            break;
                        case GeocodeQualityType.BuildingCentroid:
                            ret = NAACCRGISCoordinateQualityType.AddressPoint;
                            break;
                        case GeocodeQualityType.BuildingFrontDoor:
                            ret = NAACCRGISCoordinateQualityType.AddressPoint;
                            break;
                        case GeocodeQualityType.CityCentroid:
                            ret = NAACCRGISCoordinateQualityType.CityCentroid;
                            break;
                        case GeocodeQualityType.ConsolidatedCityCentroid:
                            ret = NAACCRGISCoordinateQualityType.CityCentroid;
                            break;
                        case GeocodeQualityType.CountryCentroid:
                            ret = NAACCRGISCoordinateQualityType.Unknown;
                            break;
                        case GeocodeQualityType.CountyCentroid:
                            ret = NAACCRGISCoordinateQualityType.CountyCentroid;
                            break;
                        case GeocodeQualityType.CountySubdivisionCentroid:
                            ret = NAACCRGISCoordinateQualityType.CountyCentroid;
                            break;
                        case GeocodeQualityType.DynamicFeatureCompositionCentroid:
                            ret = NAACCRGISCoordinateQualityType.Unknown;
                            break;
                        case GeocodeQualityType.ExactParcelCentroid:
                            ret = NAACCRGISCoordinateQualityType.Parcel;
                            break;
                        case GeocodeQualityType.ExactParcelCentroidPoint:
                            ret = NAACCRGISCoordinateQualityType.Parcel;
                            break;
                        case GeocodeQualityType.GPS:
                            ret = NAACCRGISCoordinateQualityType.GPS;
                            break;
                        case GeocodeQualityType.NearestParcelCentroid:
                            ret = NAACCRGISCoordinateQualityType.Parcel;
                            break;
                        case GeocodeQualityType.NearestParcelCentroidPoint:
                            ret = NAACCRGISCoordinateQualityType.Parcel;
                            break;
                        case GeocodeQualityType.StateCentroid:
                            ret = NAACCRGISCoordinateQualityType.Unknown;
                            break;
                        case GeocodeQualityType.StreetCentroid:
                            ret = NAACCRGISCoordinateQualityType.StreetCentroid;
                            break;
                        case GeocodeQualityType.StreetIntersection:
                            ret = NAACCRGISCoordinateQualityType.StreetIntersection;
                            break;
                        case GeocodeQualityType.UniformLotInterpolation:
                            ret = NAACCRGISCoordinateQualityType.StreetSegmentInterpolation;
                            break;
                        case GeocodeQualityType.Unknown:
                            ret = NAACCRGISCoordinateQualityType.Unknown;
                            break;
                        case GeocodeQualityType.Unmatchable:
                            ret = NAACCRGISCoordinateQualityType.Unmatchable;
                            break;


                        case GeocodeQualityType.USPSZipPlus4LineCentroid:
                            if (addressLocationTypes == AddressLocationTypes.PostOfficeBox)
                            {
                                ret = NAACCRGISCoordinateQualityType.POBoxZIPCentroid;
                            }
                            else
                            {
                                ret = NAACCRGISCoordinateQualityType.AddressZIPPlus4Centroid;
                            }
                            break;

                        case GeocodeQualityType.USPSZipPlus5LineCentroid:
                            ret = NAACCRGISCoordinateQualityType.Unknown;
                            break;


                        case GeocodeQualityType.USPSZipAreaCentroid:
                        case GeocodeQualityType.ZCTACentroid:
                            if (geocode.MatchedFeature.MatchedReferenceFeature.StreetAddressableGeographicFeature.ZIPCodeType != ZIPCodeType.Unknown)
                            {
                                if (geocode.MatchedFeature.MatchedReferenceFeature.StreetAddressableGeographicFeature.ZIPCodeType == ZIPCodeType.POBox)
                                {
                                    ret = NAACCRGISCoordinateQualityType.POBoxZIPCentroid;
                                }
                                else if (geocode.MatchedFeature.MatchedReferenceFeature.StreetAddressableGeographicFeature.ZIPCodeType == ZIPCodeType.Residential)
                                {
                                    ret = NAACCRGISCoordinateQualityType.AddressZIPCentroid;
                                }
                                else
                                {
                                    ret = NAACCRGISCoordinateQualityType.AddressZIPCentroid;
                                }
                            }
                            else
                            {
                                if (addressLocationTypes == AddressLocationTypes.PostOfficeBox
                                || addressLocationTypes == AddressLocationTypes.HighwayContractRoute
                                || addressLocationTypes == AddressLocationTypes.RuralRoute
                                || addressLocationTypes == AddressLocationTypes.StarRoute
                                || geocode.MatchedFeature.MatchedReferenceFeature.StreetAddressableGeographicFeature.ZIPCodeType == ZIPCodeType.POBox)
                                {
                                    ret = NAACCRGISCoordinateQualityType.POBoxZIPCentroid;
                                }
                                else
                                {
                                    ret = NAACCRGISCoordinateQualityType.AddressZIPCentroid;
                                }
                            }
                            break;
                        case GeocodeQualityType.USPSZipPlus1AreaCentroid:
                        case GeocodeQualityType.ZCTAPlus1Centroid:
                            ret = NAACCRGISCoordinateQualityType.Unknown;
                            break;
                        case GeocodeQualityType.USPSZipPlus2AreaCentroid:
                        case GeocodeQualityType.ZCTAPlus2Centroid:
                            if (addressLocationTypes == AddressLocationTypes.PostOfficeBox)
                            {
                                ret = NAACCRGISCoordinateQualityType.POBoxZIPCentroid;
                            }
                            else
                            {
                                ret = NAACCRGISCoordinateQualityType.AddressZIPPlus2Centroid;
                            }
                            break;
                        case GeocodeQualityType.USPSZipPlus3AreaCentroid:
                        case GeocodeQualityType.ZCTAPlus3Centroid:
                            ret = NAACCRGISCoordinateQualityType.Unknown;
                            break;
                        case GeocodeQualityType.USPSZipPlus4AreaCentroid:
                        case GeocodeQualityType.ZCTAPlus4Centroid:
                            if (addressLocationTypes == AddressLocationTypes.PostOfficeBox)
                            {
                                ret = NAACCRGISCoordinateQualityType.POBoxZIPCentroid;
                            }
                            else
                            {
                                ret = NAACCRGISCoordinateQualityType.AddressZIPPlus4Centroid;
                            }
                            break;
                        case GeocodeQualityType.USPSZipPlus5AreaCentroid:
                        case GeocodeQualityType.ZCTAPlus5Centroid:
                            ret = NAACCRGISCoordinateQualityType.Unknown;
                            break;
                        default:
                            ret = NAACCRGISCoordinateQualityType.Unknown;
                            break;
                    }
                }
            }

            return ret;
        }

        public static NAACCRGISCoordinateQualityType GetNAACCRGISCoordinateQualityTypeFromName(string quality)
        {
            NAACCRGISCoordinateQualityType ret = NAACCRGISCoordinateQualityType.Unknown;

            if (String.Compare(quality, NAACCR_GIS_COORDINATE_QUALITY_NAME_ADDRESS_POINT, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.AddressPoint;
            }
            else if (String.Compare(quality, NAACCR_GIS_COORDINATE_QUALITY_NAME_ADDRESS_ZIP_CODE_AREA_CENTROID, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.AddressZIPCentroid;
            }
            else if (String.Compare(quality, NAACCR_GIS_COORDINATE_QUALITY_NAME_ADDRESS_ZIP_CODE_PLUS_2_CENTROID, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.AddressZIPPlus2Centroid;
            }
            else if (String.Compare(quality, NAACCR_GIS_COORDINATE_QUALITY_NAME_ADDRESS_ZIP_CODE_PLUS_4_CENTROID, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.AddressZIPPlus4Centroid;
            }
            else if (String.Compare(quality, NAACCR_GIS_COORDINATE_QUALITY_NAME_CITY_CENTROID, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.CityCentroid;
            }
            else if (String.Compare(quality, NAACCR_GIS_COORDINATE_QUALITY_NAME_COUNTY_CENTROID, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.CountyCentroid;
            }
            else if (String.Compare(quality, NAACCR_GIS_COORDINATE_QUALITY_NAME_GPS, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.GPS;
            }
            else if (String.Compare(quality, NAACCR_GIS_COORDINATE_QUALITY_NAME_MANUAL_LOOKUP, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.ManualLookup;
            }
            else if (String.Compare(quality, NAACCR_GIS_COORDINATE_QUALITY_NAME_MISSING, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.Missing;
            }
            else if (String.Compare(quality, NAACCR_GIS_COORDINATE_QUALITY_NAME_PARCEL_CENTROID, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.Parcel;
            }
            else if (String.Compare(quality, NAACCR_GIS_COORDINATE_QUALITY_NAME_PO_BOX_ZIP_CODE_CENTROID, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.POBoxZIPCentroid;
            }
            else if (String.Compare(quality, NAACCR_GIS_COORDINATE_QUALITY_NAME_STREET_CENTROID, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.StreetCentroid;
            }
            else if (String.Compare(quality, NAACCR_GIS_COORDINATE_QUALITY_NAME_STREET_INTERSECTION, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.StreetIntersection;
            }
            else if (String.Compare(quality, NAACCR_GIS_COORDINATE_QUALITY_NAME_STREET_SEGMENT_INTERPOLATION, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.StreetSegmentInterpolation;
            }
            else if (String.Compare(quality, NAACCR_GIS_COORDINATE_QUALITY_NAME_UNKNOWN, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.Unknown;
            }
            else if (String.Compare(quality, NAACCR_GIS_COORDINATE_QUALITY_NAME_UNMATCHABLE, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.Unmatchable;
            }

            else
            {
                throw new Exception("Unexpected GISCoordinateQualityType: " + quality);
            }
            return ret;
        }

        public static NAACCRGISCoordinateQualityType GetNAACCRGISCoordinateQualityTypeFromCode(string code)
        {
            NAACCRGISCoordinateQualityType ret = NAACCRGISCoordinateQualityType.Unknown;

            if (String.Compare(code, NAACCR_GIS_COORDINATE_QUALITY_CODE_ADDRESS_POINT, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.AddressPoint;
            }
            else if (String.Compare(code, NAACCR_GIS_COORDINATE_QUALITY_CODE_ADDRESS_ZIP_CODE_AREA_CENTROID, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.AddressZIPCentroid;
            }
            else if (String.Compare(code, NAACCR_GIS_COORDINATE_QUALITY_CODE_ADDRESS_ZIP_CODE_PLUS_2_CENTROID, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.AddressZIPPlus2Centroid;
            }
            else if (String.Compare(code, NAACCR_GIS_COORDINATE_QUALITY_CODE_ADDRESS_ZIP_CODE_PLUS_4_CENTROID, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.AddressZIPPlus4Centroid;
            }
            else if (String.Compare(code, NAACCR_GIS_COORDINATE_QUALITY_CODE_CITY_CENTROID, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.CityCentroid;
            }
            else if (String.Compare(code, NAACCR_GIS_COORDINATE_QUALITY_CODE_COUNTY_CENTROID, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.CountyCentroid;
            }
            else if (String.Compare(code, NAACCR_GIS_COORDINATE_QUALITY_CODE_GPS, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.GPS;
            }
            else if (String.Compare(code, NAACCR_GIS_COORDINATE_QUALITY_CODE_MANUAL_LOOKUP, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.ManualLookup;
            }
            else if (String.Compare(code, NAACCR_GIS_COORDINATE_QUALITY_CODE_MISSING, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.Missing;
            }
            else if (String.Compare(code, NAACCR_GIS_COORDINATE_QUALITY_CODE_PARCEL_CENTROID, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.Parcel;
            }
            else if (String.Compare(code, NAACCR_GIS_COORDINATE_QUALITY_CODE_PO_BOX_ZIP_CODE_CENTROID, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.POBoxZIPCentroid;
            }
            else if (String.Compare(code, NAACCR_GIS_COORDINATE_QUALITY_CODE_STREET_CENTROID, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.StreetCentroid;
            }
            else if (String.Compare(code, NAACCR_GIS_COORDINATE_QUALITY_CODE_STREET_INTERSECTION, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.StreetIntersection;
            }
            else if (String.Compare(code, NAACCR_GIS_COORDINATE_QUALITY_CODE_STREET_SEGMENT_INTERPOLATION, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.StreetSegmentInterpolation;
            }
            else if (String.Compare(code, NAACCR_GIS_COORDINATE_QUALITY_CODE_UNKNOWN, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.Unknown;
            }
            else if (String.Compare(code, NAACCR_GIS_COORDINATE_QUALITY_CODE_UNMATCHABLE, true) == 0)
            {
                ret = NAACCRGISCoordinateQualityType.Unmatchable;
            }

            else
            {
                throw new Exception("Unexpected GISCoordinateQualityCode: " + code);
            }
            return ret;
        }

        public static string GetNAACCRGISCoordinateQualityName(NAACCRGISCoordinateQualityType t)
        {
            string ret = "";
            switch (t)
            {
                case NAACCRGISCoordinateQualityType.AddressPoint:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_NAME_ADDRESS_POINT;
                    break;
                case NAACCRGISCoordinateQualityType.AddressZIPCentroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_NAME_ADDRESS_ZIP_CODE_AREA_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.AddressZIPPlus2Centroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_NAME_ADDRESS_ZIP_CODE_PLUS_2_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.AddressZIPPlus4Centroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_NAME_ADDRESS_ZIP_CODE_PLUS_4_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.CityCentroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_NAME_CITY_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.CountyCentroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_NAME_COUNTY_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.GPS:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_NAME_GPS;
                    break;
                case NAACCRGISCoordinateQualityType.ManualLookup:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_NAME_MANUAL_LOOKUP;
                    break;
                case NAACCRGISCoordinateQualityType.Missing:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_NAME_MISSING;
                    break;
                case NAACCRGISCoordinateQualityType.Parcel:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_NAME_PARCEL_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.POBoxZIPCentroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_NAME_PO_BOX_ZIP_CODE_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.StreetCentroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_NAME_STREET_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.StreetIntersection:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_NAME_STREET_INTERSECTION;
                    break;
                case NAACCRGISCoordinateQualityType.StreetSegmentInterpolation:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_NAME_STREET_SEGMENT_INTERPOLATION;
                    break;
                case NAACCRGISCoordinateQualityType.Unknown:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_NAME_UNKNOWN;
                    break;
                case NAACCRGISCoordinateQualityType.Unmatchable:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_NAME_UNMATCHABLE;
                    break;


                default:
                    throw new Exception("Unexpected GISCoordinateQualityType: " + t);
            }
            return ret;
        }

        public static string GetNAACCRGISCoordinateQualityCodeFromType(string type)
        {
            NAACCRGISCoordinateQualityType t = (NAACCRGISCoordinateQualityType)Enum.Parse(typeof(NAACCRGISCoordinateQualityType), type);
            return GetNAACCRGISCoordinateQualityCode(t);
        }

        public static string GetNAACCRGISCoordinateQualityCode(NAACCRGISCoordinateQualityType t)
        {
            string ret = "";
            switch (t)
            {
                case NAACCRGISCoordinateQualityType.AddressPoint:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_CODE_ADDRESS_POINT;
                    break;
                case NAACCRGISCoordinateQualityType.AddressZIPCentroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_CODE_ADDRESS_ZIP_CODE_AREA_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.AddressZIPPlus2Centroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_CODE_ADDRESS_ZIP_CODE_PLUS_2_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.AddressZIPPlus4Centroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_CODE_ADDRESS_ZIP_CODE_PLUS_4_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.CityCentroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_CODE_CITY_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.CountyCentroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_CODE_COUNTY_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.GPS:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_CODE_GPS;
                    break;
                case NAACCRGISCoordinateQualityType.ManualLookup:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_CODE_MANUAL_LOOKUP;
                    break;
                case NAACCRGISCoordinateQualityType.Missing:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_CODE_MISSING;
                    break;
                case NAACCRGISCoordinateQualityType.Parcel:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_CODE_PARCEL_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.POBoxZIPCentroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_CODE_PO_BOX_ZIP_CODE_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.StreetCentroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_CODE_STREET_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.StreetIntersection:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_CODE_STREET_INTERSECTION;
                    break;
                case NAACCRGISCoordinateQualityType.StreetSegmentInterpolation:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_CODE_STREET_SEGMENT_INTERPOLATION;
                    break;
                case NAACCRGISCoordinateQualityType.Unknown:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_CODE_UNKNOWN;
                    break;
                case NAACCRGISCoordinateQualityType.Unmatchable:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_CODE_UNMATCHABLE;
                    break;


                default:
                    throw new Exception("Unexpected GISCoordinateQualityType: " + t);
            }
            return ret;
        }



        public static string GetNAACCRGISCoordinateQualityShortName(NAACCRGISCoordinateQualityType t)
        {
            string ret = "";
            switch (t)
            {
                case NAACCRGISCoordinateQualityType.AddressPoint:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_ADDRESS_POINT;
                    break;
                case NAACCRGISCoordinateQualityType.AddressZIPCentroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_ADDRESS_ZIP_CODE_AREA_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.AddressZIPPlus2Centroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_ADDRESS_ZIP_CODE_PLUS_2_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.AddressZIPPlus4Centroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_ADDRESS_ZIP_CODE_PLUS_4_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.CityCentroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_CITY_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.CountyCentroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_COUNTY_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.GPS:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_GPS;
                    break;
                case NAACCRGISCoordinateQualityType.ManualLookup:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_MANUAL_LOOKUP;
                    break;
                case NAACCRGISCoordinateQualityType.Missing:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_MISSING;
                    break;
                case NAACCRGISCoordinateQualityType.Parcel:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_PARCEL_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.POBoxZIPCentroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_PO_BOX_ZIP_CODE_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.StreetCentroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_STREET_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.StreetIntersection:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_STREET_INTERSECTION;
                    break;
                case NAACCRGISCoordinateQualityType.StreetSegmentInterpolation:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_STREET_SEGMENT_INTERPOLATION;
                    break;
                case NAACCRGISCoordinateQualityType.Unknown:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_UNKNOWN;
                    break;
                case NAACCRGISCoordinateQualityType.Unmatchable:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_SHORT_NAME_UNMATCHABLE;
                    break;

                default:
                    throw new Exception("Unexpected GISCoordinateQualityType: " + t);

            }
            return ret;
        }

        public static string GetNAACCRGISCoordinateQualityDescription(NAACCRGISCoordinateQualityType t)
        {
            string ret = "";
            switch (t)
            {
                case NAACCRGISCoordinateQualityType.AddressPoint:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_ADDRESS_POINT;
                    break;
                case NAACCRGISCoordinateQualityType.AddressZIPCentroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_ADDRESS_ZIP_CODE_AREA_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.AddressZIPPlus2Centroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_ADDRESS_ZIP_CODE_PLUS_2_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.AddressZIPPlus4Centroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_ADDRESS_ZIP_CODE_PLUS_4_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.CityCentroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_CITY_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.CountyCentroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_COUNTY_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.GPS:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_GPS;
                    break;
                case NAACCRGISCoordinateQualityType.ManualLookup:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_MANUAL_LOOKUP;
                    break;
                case NAACCRGISCoordinateQualityType.Missing:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_MISSING;
                    break;
                case NAACCRGISCoordinateQualityType.Parcel:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_PARCEL_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.POBoxZIPCentroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_PO_BOX_ZIP_CODE_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.StreetCentroid:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_STREET_CENTROID;
                    break;
                case NAACCRGISCoordinateQualityType.StreetIntersection:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_STREET_INTERSECTION;
                    break;
                case NAACCRGISCoordinateQualityType.StreetSegmentInterpolation:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_STREET_SEGMENT_INTERPOLATION;
                    break;
                case NAACCRGISCoordinateQualityType.Unknown:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_UNKNOWN;
                    break;
                case NAACCRGISCoordinateQualityType.Unmatchable:
                    ret = NAACCR_GIS_COORDINATE_QUALITY_DESCRIPTION_UNMATCHABLE;
                    break;

                default:
                    throw new Exception("Unexpected GISCoordinateQualityType: " + t);
            }
            return ret;
        }
    }
}
