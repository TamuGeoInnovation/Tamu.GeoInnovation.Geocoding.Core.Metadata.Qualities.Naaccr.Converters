using System;
using System.Data;
using USC.GISResearchLab.Census.Core.Configurations.ServerConfigurations;
using USC.GISResearchLab.Common.Addresses.AbstractClasses;
using USC.GISResearchLab.Geocoding.Core.Configurations;
using USC.GISResearchLab.Geocoding.Core.OutputData;
using USC.GISResearchLab.Geocoding.Core.Queries.Parameters;

namespace USC.GISResearchLab.Geocoding.Core.Metadata.Qualities
{
    public class NAACCRCensusTractCertaintyConverter
    {


        public const string NAACCR_CENSUS_TRACT_CERTAINTY_NAME_RESIDENCE_STREET_ADDRESS = "CERTAINTY_RESIDENCE_STREET_ADDRESS";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_NAME_RESIDENCE_ZIP_CODE_PLUS_4 = "CERTAINTY_RESIDENCE_ZIP_CODE_PLUS_4";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_NAME_RESIDENCE_ZIP_CODE_PLUS_2 = "CERTAINTY_RESIDENCE_ZIP_CODE_PLUS_2";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_NAME_RESIDENCE_ZIP_CODE = "CERTAINTY_RESIDENCE_ZIP";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_NAME_PO_BOX_ZIP_CODE = "CERTAINTY_PO_BOX_ZIP_CODE";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_NAME_RESIDENCE_CITY_OR_ZIP_WITH_ONE_CENSUS_TRACT = "CERTAINTY_RESIDENCE_CITY_OR_ZIP_WITH_ONE_CENSUS_TRACT";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_NAME_MISSING = "CERTAINTY_MISSING";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_NAME_NOT_ATTEMPTED = "CERTAINTY_NOT_ATTEMPTED";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_NAME_UNKNOWN = "CERTAINTY_UNKNOWN";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_NAME_UNMATCHABLE = "CERTAINTY_UNMATCHABLE";

        public const string NAACCR_CENSUS_TRACT_CERTAINTY_CODE_RESIDENCE_STREET_ADDRESS = "1";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_CODE_RESIDENCE_ZIP_CODE_PLUS_4 = "2";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_CODE_RESIDENCE_ZIP_CODE_PLUS_2 = "3";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_CODE_RESIDENCE_ZIP_CODE = "4";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_CODE_PO_BOX_ZIP_CODE = "5";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_CODE_RESIDENCE_CITY_OR_ZIP_WITH_ONE_CENSUS_TRACT = "6";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_CODE_MISSING = "9";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_CODE_UNMATCHABLE = "99";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_CODE_NOT_ATTEMPTED = "";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_CODE_UNKNOWN = "";

        public const string NAACCR_CENSUS_TRACT_CERTAINTY_SHORT_NAME_RESIDENCE_STREET_ADDRESS = "res addr";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_SHORT_NAME_RESIDENCE_ZIP_CODE_PLUS_4 = "res zip+4";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_SHORT_NAME_RESIDENCE_ZIP_CODE_PLUS_2 = "res zip+5";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_SHORT_NAME_RESIDENCE_ZIP_CODE = "res zip";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_SHORT_NAME_PO_BOX_ZIP_CODE = "pobox zip";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_SHORT_NAME_RESIDENCE_CITY_OR_ZIP_WITH_ONE_CENSUS_TRACT = "city/zip 1 tract";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_SHORT_NAME_MISSING = "missing";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_SHORT_NAME_UNMATCHABLE = "unmatchable";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_SHORT_NAME_NOT_ATTEMPTED = "not attempt";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_SHORT_NAME_UNKNOWN = "unk";


        public const string NAACCR_CENSUS_TRACT_CERTAINTY_DESCRIPTION_RESIDENCE_STREET_ADDRESS = "Census tract based on complete and valid street address of residence";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_DESCRIPTION_RESIDENCE_ZIP_CODE_PLUS_4 = "Census tract based on residence ZIP + 4";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_DESCRIPTION_RESIDENCE_ZIP_CODE_PLUS_2 = "Census tract based on residence ZIP + 2";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_DESCRIPTION_RESIDENCE_ZIP_CODE = "Census tract based on residence ZIP code only";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_DESCRIPTION_PO_BOX_ZIP_CODE = "Census tract based on ZIP code of P.O. Box";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_DESCRIPTION_RESIDENCE_CITY_OR_ZIP_WITH_ONE_CENSUS_TRACT = "Census tract/BNA based on residence city where city has only one census tract, or based on residence ZIP code where ZIP code has only one census tract";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_DESCRIPTION_MISSING = "Not assigned, geocoding attempted";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_DESCRIPTION_NOT_ATTEMPTED = "Not assigned, geocoding not attempted";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_DESCRIPTION_UNMATCHABLE = "Geocoding attempted, unable to assign";
        public const string NAACCR_CENSUS_TRACT_CERTAINTY_DESCRIPTION_UNKNOWN = "Unknown";


        public static DataTable GetAllQualities()
        {
            DataTable ret = new DataTable();
            ret.Columns.Add(new DataColumn("id", typeof(int)));
            ret.Columns.Add(new DataColumn("code", typeof(string)));
            ret.Columns.Add(new DataColumn("name", typeof(string)));
            ret.Columns.Add(new DataColumn("description", typeof(string)));
            ret.Columns.Add(new DataColumn("value", typeof(string)));

            //DataRow row = null;

            foreach (NAACCRCensusTractCertaintyType item in Enum.GetValues(typeof(NAACCRCensusTractCertaintyType)))
            {
                DataRow row = ret.NewRow();
                row["id"] = (int)item;
                row["code"] = GetNAACCRCensusTractCertaintyCode(item);
                row["name"] = GetNAACCRCensusTractCertaintyName(item);
                row["description"] = GetNAACCRCensusTractCertaintyDescription(item);
                row["value"] = item.ToString();
                ret.Rows.Add(row);
            }


            return ret;
        }

        public static NAACCRCensusTractCertaintyType GetNAACCRCensusTractCertaintyTypeForGeocode(IGeocode geocode, ParameterSet parameterSet, GeocoderConfiguration geocoderConfiguration)
        {
            CensusYear censusYear = CensusYear.TwoThousandTen;

            if (parameterSet != null)
            {
                if (geocoderConfiguration != null)
                {
                    if (geocoderConfiguration.CensusConfiguration != null)
                    {
                        if (geocoderConfiguration.CensusConfiguration.CensusYearConfiguration != null)
                        {
                            censusYear = geocoderConfiguration.CensusConfiguration.CensusYearConfiguration.CensusYear;
                        }
                    }
                }
            }

            return GetNAACCRCensusTractCertaintyTypeForGeocode(geocode, censusYear);
        }

        public static NAACCRCensusTractCertaintyType GetNAACCRCensusTractCertaintyTypeForGeocode(IGeocode geocode, CensusYear censusYear)
        {

            NAACCRCensusTractCertaintyType ret = NAACCRCensusTractCertaintyType.Unknown;

            GeocodeQualityType geocodeQualityType = geocode.GeocodeQualityType;

            if (geocode.InputAddress != null)
            {
                AddressLocationTypes addressLocationTypes = geocode.InputAddress.AddressLocationType;

                if (addressLocationTypes != AddressLocationTypes.Unknown)
                {
                    switch (geocodeQualityType)
                    {
                        case GeocodeQualityType.ActualLotInterpolation:
                            ret = NAACCRCensusTractCertaintyType.ResidenceStreetAddress;
                            break;
                        case GeocodeQualityType.AddressRangeInterpolation:
                            ret = NAACCRCensusTractCertaintyType.ResidenceStreetAddress;
                            break;
                        case GeocodeQualityType.BuildingCentroid:
                            ret = NAACCRCensusTractCertaintyType.ResidenceStreetAddress;
                            break;
                        case GeocodeQualityType.BuildingFrontDoor:
                            ret = NAACCRCensusTractCertaintyType.ResidenceStreetAddress;
                            break;
                        case GeocodeQualityType.CityCentroid:

                            if (censusYear == CensusYear.TwoThousand)
                            {
                                if (geocode.MatchedFeature.MatchedReferenceFeature.StreetAddressableGeographicFeature.NumTracts2000 == 1)
                                {
                                    ret = NAACCRCensusTractCertaintyType.ResidenceCityOrZIPWithOneCensusTract;
                                }
                                else
                                {
                                    ret = NAACCRCensusTractCertaintyType.Missing;
                                }
                            }

                            if (censusYear == CensusYear.TwoThousandTen)
                            {
                                if (geocode.MatchedFeature.MatchedReferenceFeature.StreetAddressableGeographicFeature.NumTracts2010 == 1)
                                {
                                    ret = NAACCRCensusTractCertaintyType.ResidenceCityOrZIPWithOneCensusTract;
                                }
                                else
                                {
                                    ret = NAACCRCensusTractCertaintyType.Missing;
                                }
                            }

                            break;
                        case GeocodeQualityType.ConsolidatedCityCentroid:
                            ret = NAACCRCensusTractCertaintyType.Missing;
                            break;
                        case GeocodeQualityType.CountryCentroid:
                            ret = NAACCRCensusTractCertaintyType.Missing;
                            break;
                        case GeocodeQualityType.CountyCentroid:
                            ret = NAACCRCensusTractCertaintyType.Missing;
                            break;
                        case GeocodeQualityType.CountySubdivisionCentroid:
                            ret = NAACCRCensusTractCertaintyType.Missing;
                            break;
                        case GeocodeQualityType.DynamicFeatureCompositionCentroid:
                            ret = NAACCRCensusTractCertaintyType.Missing;
                            break;
                        case GeocodeQualityType.ExactParcelCentroid:
                            ret = NAACCRCensusTractCertaintyType.ResidenceStreetAddress;
                            break;
                        case GeocodeQualityType.ExactParcelCentroidPoint:
                            ret = NAACCRCensusTractCertaintyType.ResidenceStreetAddress;
                            break;
                        case GeocodeQualityType.GPS:
                            ret = NAACCRCensusTractCertaintyType.Missing;
                            break;
                        case GeocodeQualityType.NearestParcelCentroid:
                            ret = NAACCRCensusTractCertaintyType.ResidenceStreetAddress;
                            break;
                        case GeocodeQualityType.NearestParcelCentroidPoint:
                            ret = NAACCRCensusTractCertaintyType.ResidenceStreetAddress;
                            break;
                        case GeocodeQualityType.StateCentroid:
                            ret = NAACCRCensusTractCertaintyType.Missing;
                            break;
                        case GeocodeQualityType.StreetCentroid:
                            ret = NAACCRCensusTractCertaintyType.Missing;
                            break;
                        case GeocodeQualityType.StreetIntersection:
                            ret = NAACCRCensusTractCertaintyType.Missing;
                            break;
                        case GeocodeQualityType.UniformLotInterpolation:
                            ret = NAACCRCensusTractCertaintyType.ResidenceStreetAddress;
                            break;
                        case GeocodeQualityType.Unknown:
                            ret = NAACCRCensusTractCertaintyType.Unknown;
                            break;
                        case GeocodeQualityType.Unmatchable:
                            ret = NAACCRCensusTractCertaintyType.Missing;
                            break;


                        case GeocodeQualityType.USPSZipPlus4LineCentroid:
                            if (addressLocationTypes == AddressLocationTypes.PostOfficeBox)
                            {
                                ret = NAACCRCensusTractCertaintyType.POBoxZIP;
                            }
                            else
                            {
                                ret = NAACCRCensusTractCertaintyType.ResidenceZIPPlus4;
                            }
                            break;

                        case GeocodeQualityType.USPSZipPlus5LineCentroid:
                            ret = NAACCRCensusTractCertaintyType.Missing;
                            break;


                        case GeocodeQualityType.USPSZipAreaCentroid:
                        case GeocodeQualityType.ZCTACentroid:


                            if (addressLocationTypes == AddressLocationTypes.PostOfficeBox
                                || addressLocationTypes == AddressLocationTypes.HighwayContractRoute
                                || addressLocationTypes == AddressLocationTypes.RuralRoute
                                || addressLocationTypes == AddressLocationTypes.StarRoute
                                || geocode.MatchedFeature.MatchedReferenceFeature.StreetAddressableGeographicFeature.ZIPCodeType == ZIPCodeType.POBox
                                )
                            {
                                ret = NAACCRCensusTractCertaintyType.POBoxZIP;
                            }
                            else
                            {
                                if (censusYear == CensusYear.TwoThousand)
                                {
                                    if (geocode.MatchedFeature.MatchedReferenceFeature.StreetAddressableGeographicFeature.NumTracts2000 == 1)
                                    {
                                        ret = NAACCRCensusTractCertaintyType.ResidenceCityOrZIPWithOneCensusTract;
                                    }
                                    else
                                    {
                                        ret = NAACCRCensusTractCertaintyType.ResidenceZIP;
                                    }
                                }

                                if (censusYear == CensusYear.TwoThousandTen)
                                {
                                    if (geocode.MatchedFeature.MatchedReferenceFeature.StreetAddressableGeographicFeature.NumTracts2010 == 1)
                                    {
                                        ret = NAACCRCensusTractCertaintyType.ResidenceCityOrZIPWithOneCensusTract;
                                    }
                                    else
                                    {
                                        ret = NAACCRCensusTractCertaintyType.ResidenceZIP;
                                    }
                                }
                            }
                            break;
                        case GeocodeQualityType.USPSZipPlus1AreaCentroid:
                        case GeocodeQualityType.ZCTAPlus1Centroid:
                            ret = NAACCRCensusTractCertaintyType.Missing;
                            break;
                        case GeocodeQualityType.USPSZipPlus2AreaCentroid:
                        case GeocodeQualityType.ZCTAPlus2Centroid:
                            if (addressLocationTypes == AddressLocationTypes.PostOfficeBox)
                            {
                                ret = NAACCRCensusTractCertaintyType.POBoxZIP;
                            }
                            else
                            {
                                ret = NAACCRCensusTractCertaintyType.ResidenceZIPPlus2;
                            }
                            break;
                        case GeocodeQualityType.USPSZipPlus3AreaCentroid:
                        case GeocodeQualityType.ZCTAPlus3Centroid:
                            ret = NAACCRCensusTractCertaintyType.Missing;
                            break;
                        case GeocodeQualityType.USPSZipPlus4AreaCentroid:
                        case GeocodeQualityType.ZCTAPlus4Centroid:
                            if (addressLocationTypes == AddressLocationTypes.PostOfficeBox)
                            {
                                ret = NAACCRCensusTractCertaintyType.POBoxZIP;
                            }
                            else
                            {
                                ret = NAACCRCensusTractCertaintyType.ResidenceZIPPlus4;
                            }
                            break;
                        case GeocodeQualityType.USPSZipPlus5AreaCentroid:
                        case GeocodeQualityType.ZCTAPlus5Centroid:
                            ret = NAACCRCensusTractCertaintyType.Missing;
                            break;
                        default:
                            ret = NAACCRCensusTractCertaintyType.Unknown;
                            break;
                    }
                }
            }
            return ret;
        }

        public static NAACCRCensusTractCertaintyType GetNAACCRNAACCRCensusTractCertaintyTypeFromCode(string code)
        {
            NAACCRCensusTractCertaintyType ret = NAACCRCensusTractCertaintyType.Unknown;

            if (String.Compare(code, NAACCR_CENSUS_TRACT_CERTAINTY_CODE_MISSING, true) == 0)
            {
                ret = NAACCRCensusTractCertaintyType.Missing;
            }
            else if (String.Compare(code, NAACCR_CENSUS_TRACT_CERTAINTY_CODE_NOT_ATTEMPTED, true) == 0)
            {
                ret = NAACCRCensusTractCertaintyType.NotAttempted;
            }
            else if (String.Compare(code, NAACCR_CENSUS_TRACT_CERTAINTY_CODE_PO_BOX_ZIP_CODE, true) == 0)
            {
                ret = NAACCRCensusTractCertaintyType.POBoxZIP;
            }
            else if (String.Compare(code, NAACCR_CENSUS_TRACT_CERTAINTY_CODE_RESIDENCE_CITY_OR_ZIP_WITH_ONE_CENSUS_TRACT, true) == 0)
            {
                ret = NAACCRCensusTractCertaintyType.ResidenceCityOrZIPWithOneCensusTract;
            }
            else if (String.Compare(code, NAACCR_CENSUS_TRACT_CERTAINTY_CODE_RESIDENCE_STREET_ADDRESS, true) == 0)
            {
                ret = NAACCRCensusTractCertaintyType.ResidenceStreetAddress;
            }
            else if (String.Compare(code, NAACCR_CENSUS_TRACT_CERTAINTY_CODE_RESIDENCE_ZIP_CODE, true) == 0)
            {
                ret = NAACCRCensusTractCertaintyType.ResidenceZIP;
            }
            else if (String.Compare(code, NAACCR_CENSUS_TRACT_CERTAINTY_CODE_RESIDENCE_ZIP_CODE_PLUS_2, true) == 0)
            {
                ret = NAACCRCensusTractCertaintyType.ResidenceZIPPlus2;
            }
            else if (String.Compare(code, NAACCR_CENSUS_TRACT_CERTAINTY_CODE_RESIDENCE_ZIP_CODE_PLUS_4, true) == 0)
            {
                ret = NAACCRCensusTractCertaintyType.ResidenceZIPPlus4;
            }
            else if (String.Compare(code, NAACCR_CENSUS_TRACT_CERTAINTY_CODE_UNKNOWN, true) == 0)
            {
                ret = NAACCRCensusTractCertaintyType.Unknown;
            }
            else if (String.Compare(code, NAACCR_CENSUS_TRACT_CERTAINTY_CODE_UNMATCHABLE, true) == 0)
            {
                ret = NAACCRCensusTractCertaintyType.Unmatchable;
            }


            else
            {
                throw new Exception("Unexpected NAACCRCensusTractCertaintyCode: " + code);
            }
            return ret;
        }

        public static NAACCRCensusTractCertaintyType GetNAACCRNAACCRCensusTractCertaintyTypeFromName(string quality)
        {
            NAACCRCensusTractCertaintyType ret = NAACCRCensusTractCertaintyType.Unknown;

            if (String.Compare(quality, NAACCR_CENSUS_TRACT_CERTAINTY_NAME_MISSING, true) == 0)
            {
                ret = NAACCRCensusTractCertaintyType.Missing;
            }
            else if (String.Compare(quality, NAACCR_CENSUS_TRACT_CERTAINTY_NAME_NOT_ATTEMPTED, true) == 0)
            {
                ret = NAACCRCensusTractCertaintyType.NotAttempted;
            }
            else if (String.Compare(quality, NAACCR_CENSUS_TRACT_CERTAINTY_NAME_PO_BOX_ZIP_CODE, true) == 0)
            {
                ret = NAACCRCensusTractCertaintyType.POBoxZIP;
            }
            else if (String.Compare(quality, NAACCR_CENSUS_TRACT_CERTAINTY_NAME_RESIDENCE_CITY_OR_ZIP_WITH_ONE_CENSUS_TRACT, true) == 0)
            {
                ret = NAACCRCensusTractCertaintyType.ResidenceCityOrZIPWithOneCensusTract;
            }
            else if (String.Compare(quality, NAACCR_CENSUS_TRACT_CERTAINTY_NAME_RESIDENCE_STREET_ADDRESS, true) == 0)
            {
                ret = NAACCRCensusTractCertaintyType.ResidenceStreetAddress;
            }
            else if (String.Compare(quality, NAACCR_CENSUS_TRACT_CERTAINTY_NAME_RESIDENCE_ZIP_CODE, true) == 0)
            {
                ret = NAACCRCensusTractCertaintyType.ResidenceZIP;
            }
            else if (String.Compare(quality, NAACCR_CENSUS_TRACT_CERTAINTY_NAME_RESIDENCE_ZIP_CODE_PLUS_2, true) == 0)
            {
                ret = NAACCRCensusTractCertaintyType.ResidenceZIPPlus2;
            }
            else if (String.Compare(quality, NAACCR_CENSUS_TRACT_CERTAINTY_NAME_RESIDENCE_ZIP_CODE_PLUS_4, true) == 0)
            {
                ret = NAACCRCensusTractCertaintyType.ResidenceZIPPlus4;
            }
            else if (String.Compare(quality, NAACCR_CENSUS_TRACT_CERTAINTY_NAME_UNKNOWN, true) == 0)
            {
                ret = NAACCRCensusTractCertaintyType.Unknown;
            }
            else if (String.Compare(quality, NAACCR_CENSUS_TRACT_CERTAINTY_NAME_UNMATCHABLE, true) == 0)
            {
                ret = NAACCRCensusTractCertaintyType.Unmatchable;
            }


            else
            {
                throw new Exception("Unexpected NAACCRCensusTractCertaintyType: " + quality);
            }
            return ret;
        }

        public static string GetNAACCRCensusTractCertaintyName(NAACCRCensusTractCertaintyType t)
        {
            string ret = "";
            switch (t)
            {
                case NAACCRCensusTractCertaintyType.Missing:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_NAME_MISSING;
                    break;
                case NAACCRCensusTractCertaintyType.NotAttempted:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_NAME_NOT_ATTEMPTED;
                    break;
                case NAACCRCensusTractCertaintyType.POBoxZIP:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_NAME_PO_BOX_ZIP_CODE;
                    break;
                case NAACCRCensusTractCertaintyType.ResidenceCityOrZIPWithOneCensusTract:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_NAME_RESIDENCE_CITY_OR_ZIP_WITH_ONE_CENSUS_TRACT;
                    break;
                case NAACCRCensusTractCertaintyType.ResidenceStreetAddress:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_NAME_RESIDENCE_STREET_ADDRESS;
                    break;
                case NAACCRCensusTractCertaintyType.ResidenceZIP:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_NAME_RESIDENCE_ZIP_CODE;
                    break;
                case NAACCRCensusTractCertaintyType.ResidenceZIPPlus2:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_NAME_RESIDENCE_ZIP_CODE_PLUS_2;
                    break;
                case NAACCRCensusTractCertaintyType.ResidenceZIPPlus4:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_NAME_RESIDENCE_ZIP_CODE_PLUS_4;
                    break;
                case NAACCRCensusTractCertaintyType.Unknown:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_NAME_UNKNOWN;
                    break;
                case NAACCRCensusTractCertaintyType.Unmatchable:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_NAME_UNMATCHABLE;
                    break;

                default:
                    throw new Exception("Unexpected NAACCRCensusTractCertaintyType: " + t);
            }
            return ret;
        }

        public static string GetNAACCRCensusTractCertaintyCodeFromType(string type)
        {
            NAACCRCensusTractCertaintyType t = (NAACCRCensusTractCertaintyType)Enum.Parse(typeof(NAACCRCensusTractCertaintyType), type);
            return GetNAACCRCensusTractCertaintyCode(t);
        }

        public static string GetNAACCRCensusTractCertaintyCode(NAACCRCensusTractCertaintyType t)
        {
            string ret = "";
            switch (t)
            {
                case NAACCRCensusTractCertaintyType.Missing:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_CODE_MISSING;
                    break;
                case NAACCRCensusTractCertaintyType.NotAttempted:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_CODE_NOT_ATTEMPTED;
                    break;
                case NAACCRCensusTractCertaintyType.POBoxZIP:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_CODE_PO_BOX_ZIP_CODE;
                    break;
                case NAACCRCensusTractCertaintyType.ResidenceCityOrZIPWithOneCensusTract:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_CODE_RESIDENCE_CITY_OR_ZIP_WITH_ONE_CENSUS_TRACT;
                    break;
                case NAACCRCensusTractCertaintyType.ResidenceStreetAddress:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_CODE_RESIDENCE_STREET_ADDRESS;
                    break;
                case NAACCRCensusTractCertaintyType.ResidenceZIP:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_CODE_RESIDENCE_ZIP_CODE;
                    break;
                case NAACCRCensusTractCertaintyType.ResidenceZIPPlus2:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_CODE_RESIDENCE_ZIP_CODE_PLUS_2;
                    break;
                case NAACCRCensusTractCertaintyType.ResidenceZIPPlus4:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_CODE_RESIDENCE_ZIP_CODE_PLUS_4;
                    break;
                case NAACCRCensusTractCertaintyType.Unknown:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_CODE_UNKNOWN;
                    break;
                case NAACCRCensusTractCertaintyType.Unmatchable:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_CODE_UNMATCHABLE;
                    break;


                default:
                    throw new Exception("Unexpected NAACCRCensusTractCertaintyType: " + t);
            }
            return ret;
        }

        public static string GetNAACCRCensusTractCertaintyShortName(NAACCRCensusTractCertaintyType t)
        {
            string ret = "";
            switch (t)
            {
                case NAACCRCensusTractCertaintyType.Missing:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_SHORT_NAME_MISSING;
                    break;
                case NAACCRCensusTractCertaintyType.NotAttempted:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_SHORT_NAME_NOT_ATTEMPTED;
                    break;
                case NAACCRCensusTractCertaintyType.POBoxZIP:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_SHORT_NAME_PO_BOX_ZIP_CODE;
                    break;
                case NAACCRCensusTractCertaintyType.ResidenceCityOrZIPWithOneCensusTract:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_SHORT_NAME_RESIDENCE_CITY_OR_ZIP_WITH_ONE_CENSUS_TRACT;
                    break;
                case NAACCRCensusTractCertaintyType.ResidenceStreetAddress:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_SHORT_NAME_RESIDENCE_STREET_ADDRESS;
                    break;
                case NAACCRCensusTractCertaintyType.ResidenceZIP:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_SHORT_NAME_RESIDENCE_ZIP_CODE;
                    break;
                case NAACCRCensusTractCertaintyType.ResidenceZIPPlus2:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_SHORT_NAME_RESIDENCE_ZIP_CODE_PLUS_2;
                    break;
                case NAACCRCensusTractCertaintyType.ResidenceZIPPlus4:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_SHORT_NAME_RESIDENCE_ZIP_CODE_PLUS_4;
                    break;
                case NAACCRCensusTractCertaintyType.Unknown:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_SHORT_NAME_UNKNOWN;
                    break;
                case NAACCRCensusTractCertaintyType.Unmatchable:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_SHORT_NAME_UNMATCHABLE;
                    break;


                default:
                    throw new Exception("Unexpected NAACCRCensusTractCertaintyType: " + t);

            }
            return ret;
        }

        public static string GetNAACCRCensusTractCertaintyDescription(NAACCRCensusTractCertaintyType t)
        {
            string ret = "";
            switch (t)
            {
                case NAACCRCensusTractCertaintyType.Missing:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_DESCRIPTION_MISSING;
                    break;
                case NAACCRCensusTractCertaintyType.NotAttempted:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_DESCRIPTION_NOT_ATTEMPTED;
                    break;
                case NAACCRCensusTractCertaintyType.POBoxZIP:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_DESCRIPTION_PO_BOX_ZIP_CODE;
                    break;
                case NAACCRCensusTractCertaintyType.ResidenceCityOrZIPWithOneCensusTract:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_DESCRIPTION_RESIDENCE_CITY_OR_ZIP_WITH_ONE_CENSUS_TRACT;
                    break;
                case NAACCRCensusTractCertaintyType.ResidenceStreetAddress:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_DESCRIPTION_RESIDENCE_STREET_ADDRESS;
                    break;
                case NAACCRCensusTractCertaintyType.ResidenceZIP:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_DESCRIPTION_RESIDENCE_ZIP_CODE;
                    break;
                case NAACCRCensusTractCertaintyType.ResidenceZIPPlus2:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_DESCRIPTION_RESIDENCE_ZIP_CODE_PLUS_2;
                    break;
                case NAACCRCensusTractCertaintyType.ResidenceZIPPlus4:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_DESCRIPTION_RESIDENCE_ZIP_CODE_PLUS_4;
                    break;
                case NAACCRCensusTractCertaintyType.Unknown:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_DESCRIPTION_UNKNOWN;
                    break;
                case NAACCRCensusTractCertaintyType.Unmatchable:
                    ret = NAACCR_CENSUS_TRACT_CERTAINTY_DESCRIPTION_UNMATCHABLE;
                    break;


                default:
                    throw new Exception("Unexpected NAACCRCensusTractCertaintyType: " + t);
            }
            return ret;
        }
    }
}
