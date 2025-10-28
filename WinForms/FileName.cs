--
--PostgreSQL database dump
--

-- Dumped from database version 17.2
-- Dumped by pg_dump version 17.2

-- Started on 2025-10-28 16:47:37

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
--TOC entry 228 (class 1259 OID 33213)
-- Name: auth_group; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.auth_group(
    id_auth_group integer NOT NULL,
    name character varying(150) NOT NULL
);


ALTER TABLE public.auth_group OWNER TO postgres;

--
--TOC entry 227 (class 1259 OID 33212)
-- Name: auth_group_id_auth_group_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.auth_group_id_auth_group_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.auth_group_id_auth_group_seq OWNER TO postgres;

--
--TOC entry 5005 (class 0 OID 0)
-- Dependencies: 227
-- Name: auth_group_id_auth_group_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.auth_group_id_auth_group_seq OWNED BY public.auth_group.id_auth_group;


--
--TOC entry 230 (class 1259 OID 33222)
-- Name: auth_user; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.auth_user(
    id_auth_user integer NOT NULL,
    password character varying(128) NOT NULL,
    last_login timestamp with time zone,
    is_superuser boolean NOT NULL,
    username character varying(150) NOT NULL,
    first_name character varying(150) NOT NULL,
    last_name character varying(150) NOT NULL,
    email character varying(254) NOT NULL,
    is_staff boolean NOT NULL,
    is_active boolean NOT NULL,
    data_joined timestamp with time zone NOT NULL
);


ALTER TABLE public.auth_user OWNER TO postgres;

--
--TOC entry 229 (class 1259 OID 33221)
-- Name: auth_user_id_auth_user_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.auth_user_id_auth_user_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.auth_user_id_auth_user_seq OWNER TO postgres;

--
--TOC entry 5006 (class 0 OID 0)
-- Dependencies: 229
-- Name: auth_user_id_auth_user_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.auth_user_id_auth_user_seq OWNED BY public.auth_user.id_auth_user;


--
--TOC entry 240 (class 1259 OID 33333)
-- Name: calculation; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.calculation(
    id_calculation integer NOT NULL,
    id_line integer NOT NULL,
    id_auth_user integer NOT NULL,
    calculation_number integer NOT NULL,
    calculation_date timestamp with time zone NOT NULL
);


ALTER TABLE public.calculation OWNER TO postgres;

--
--TOC entry 239 (class 1259 OID 33332)
-- Name: calculation_id_calculation_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.calculation_id_calculation_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.calculation_id_calculation_seq OWNER TO postgres;

--
--TOC entry 5007 (class 0 OID 0)
-- Dependencies: 239
-- Name: calculation_id_calculation_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.calculation_id_calculation_seq OWNED BY public.calculation.id_calculation;


--
--TOC entry 222 (class 1259 OID 33168)
-- Name: coefficient_type; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.coefficient_type(
    id_coefficient_type integer NOT NULL,
    code character varying(50) NOT NULL,
    name character varying(150) NOT NULL,
    description text
);


ALTER TABLE public.coefficient_type OWNER TO postgres;

--
--TOC entry 221 (class 1259 OID 33167)
-- Name: coefficient_type_id_coefficient_type_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.coefficient_type_id_coefficient_type_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.coefficient_type_id_coefficient_type_seq OWNER TO postgres;

--
--TOC entry 5008 (class 0 OID 0)
-- Dependencies: 221
-- Name: coefficient_type_id_coefficient_type_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.coefficient_type_id_coefficient_type_seq OWNED BY public.coefficient_type.id_coefficient_type;


--
--TOC entry 244 (class 1259 OID 33481)
-- Name: component; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.component(
    id_component integer NOT NULL,
    id_component_coefficient integer NOT NULL,
    is_active boolean NOT NULL,
    description text NOT NULL,
    setting_designation character varying(100) NOT NULL,
    name character varying(100) NOT NULL
);


ALTER TABLE public.component OWNER TO postgres;

--
--TOC entry 243 (class 1259 OID 33480)
-- Name: component_id_component_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.component_id_component_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.component_id_component_seq OWNER TO postgres;

--
--TOC entry 5009 (class 0 OID 0)
-- Dependencies: 243
-- Name: component_id_component_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.component_id_component_seq OWNED BY public.component.id_component;


--
--TOC entry 242 (class 1259 OID 33352)
-- Name: fault_calculation; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.fault_calculation(
    id_fault_calculation integer NOT NULL,
    id_calculation_meta integer NOT NULL,
    id_protection_half_set integer NOT NULL,
    fault_type character varying(255) NOT NULL,
    fault_values jsonb NOT NULL,
    fault_location character varying(255) NOT NULL,
    network_topology character varying(255) NOT NULL
);


ALTER TABLE public.fault_calculation OWNER TO postgres;

--
--TOC entry 241 (class 1259 OID 33351)
-- Name: fault_calculation_id_fault_calculation_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.fault_calculation_id_fault_calculation_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.fault_calculation_id_fault_calculation_seq OWNER TO postgres;

--
--TOC entry 5010 (class 0 OID 0)
-- Dependencies: 241
-- Name: fault_calculation_id_fault_calculation_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.fault_calculation_id_fault_calculation_seq OWNED BY public.fault_calculation.id_fault_calculation;


--
--TOC entry 232 (class 1259 OID 33235)
-- Name: line; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.line(
    id_line integer NOT NULL,
    id_line_type integer NOT NULL,
    dispatch_name character varying(100) NOT NULL,
    pf_name character varying(100) NOT NULL,
    current_capacity double precision NOT NULL,
    length double precision NOT NULL,
    manual_ct_ratio double precision NOT NULL,
    manual_vt_ratio double precision NOT NULL,
    branch_count integer,
    is_offset_applied boolean NOT NULL,
    zero_sequence_voltage double precision,
    offset_coefficient double precision
);


ALTER TABLE public.line OWNER TO postgres;

--
--TOC entry 234 (class 1259 OID 33251)
-- Name: line_branch; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.line_branch(
    id_branch integer NOT NULL,
    id_line integer NOT NULL,
    id_substation integer NOT NULL,
    dispatch_name character varying(100),
    pf_name character varying(100) NOT NULL,
    length double precision NOT NULL,
    is_active boolean NOT NULL
);


ALTER TABLE public.line_branch OWNER TO postgres;

--
--TOC entry 233 (class 1259 OID 33250)
-- Name: line_branch_id_branch_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.line_branch_id_branch_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.line_branch_id_branch_seq OWNER TO postgres;

--
--TOC entry 5011 (class 0 OID 0)
-- Dependencies: 233
-- Name: line_branch_id_branch_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.line_branch_id_branch_seq OWNED BY public.line_branch.id_branch;


--
--TOC entry 231 (class 1259 OID 33234)
-- Name: line_id_line_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.line_id_line_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.line_id_line_seq OWNER TO postgres;

--
--TOC entry 5012 (class 0 OID 0)
-- Dependencies: 231
-- Name: line_id_line_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.line_id_line_seq OWNED BY public.line.id_line;


--
--TOC entry 218 (class 1259 OID 33146)
-- Name: line_type; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.line_type(
    id_line_type integer NOT NULL,
    type_code character varying(100) NOT NULL,
    protection_recommendation text
);


ALTER TABLE public.line_type OWNER TO postgres;

--
--TOC entry 217 (class 1259 OID 33145)
-- Name: line_type_id_line_type_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.line_type_id_line_type_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.line_type_id_line_type_seq OWNER TO postgres;

--
--TOC entry 5013 (class 0 OID 0)
-- Dependencies: 217
-- Name: line_type_id_line_type_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.line_type_id_line_type_seq OWNED BY public.line_type.id_line_type;


--
--TOC entry 226 (class 1259 OID 33199)
-- Name: manufacturer; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.manufacturer(
    id_manufacturer integer NOT NULL,
    id_methodology integer,
    name character varying(150) NOT NULL
);


ALTER TABLE public.manufacturer OWNER TO postgres;

--
--TOC entry 225 (class 1259 OID 33198)
-- Name: manufacturer_id_manufacturer_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.manufacturer_id_manufacturer_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.manufacturer_id_manufacturer_seq OWNER TO postgres;

--
--TOC entry 5014 (class 0 OID 0)
-- Dependencies: 225
-- Name: manufacturer_id_manufacturer_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.manufacturer_id_manufacturer_seq OWNED BY public.manufacturer.id_manufacturer;


--
--TOC entry 224 (class 1259 OID 33190)
-- Name: methodology_document; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.methodology_document(
    id_methodology integer NOT NULL,
    methodology_url character varying(255) NOT NULL,
    created_at timestamp with time zone NOT NULL,
    updated_at timestamp with time zone NOT NULL
);


ALTER TABLE public.methodology_document OWNER TO postgres;

--
--TOC entry 223 (class 1259 OID 33189)
-- Name: methodology_document_id_methodology_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.methodology_document_id_methodology_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.methodology_document_id_methodology_seq OWNER TO postgres;

--
--TOC entry 5015 (class 0 OID 0)
-- Dependencies: 223
-- Name: methodology_document_id_methodology_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.methodology_document_id_methodology_seq OWNED BY public.methodology_document.id_methodology;


--
--TOC entry 246 (class 1259 OID 33497)
-- Name: protection_component_coefficient; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.protection_component_coefficient(
    id_component_coefficient integer NOT NULL,
    id_component integer NOT NULL,
    id_coefficient_type integer NOT NULL,
    default_value double precision NOT NULL,
    min_value double precision,
    max_value double precision
);


ALTER TABLE public.protection_component_coefficient OWNER TO postgres;

--
--TOC entry 245 (class 1259 OID 33496)
-- Name: protection_component_coefficient_id_component_coefficient_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.protection_component_coefficient_id_component_coefficient_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.protection_component_coefficient_id_component_coefficient_seq OWNER TO postgres;

--
--TOC entry 5016 (class 0 OID 0)
-- Dependencies: 245
-- Name: protection_component_coefficient_id_component_coefficient_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.protection_component_coefficient_id_component_coefficient_seq OWNED BY public.protection_component_coefficient.id_component_coefficient;


--
--TOC entry 236 (class 1259 OID 33272)
-- Name: protection_device; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.protection_device(
    id_device integer NOT NULL,
    id_manufacturer integer NOT NULL,
    device_model character varying(100) NOT NULL
);


ALTER TABLE public.protection_device OWNER TO postgres;

--
--TOC entry 248 (class 1259 OID 33516)
-- Name: protection_device_component; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.protection_device_component(
    id integer NOT NULL,
    id_protection_device integer NOT NULL,
    id_component integer NOT NULL
);


ALTER TABLE public.protection_device_component OWNER TO postgres;

--
--TOC entry 247 (class 1259 OID 33515)
-- Name: protection_device_component_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.protection_device_component_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.protection_device_component_id_seq OWNER TO postgres;

--
--TOC entry 5017 (class 0 OID 0)
-- Dependencies: 247
-- Name: protection_device_component_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.protection_device_component_id_seq OWNED BY public.protection_device_component.id;


--
--TOC entry 235 (class 1259 OID 33271)
-- Name: protection_device_id_device_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.protection_device_id_device_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.protection_device_id_device_seq OWNER TO postgres;

--
--TOC entry 5018 (class 0 OID 0)
-- Dependencies: 235
-- Name: protection_device_id_device_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.protection_device_id_device_seq OWNED BY public.protection_device.id_device;


--
--TOC entry 238 (class 1259 OID 33311)
-- Name: protection_half_set; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.protection_half_set(
    id_protection_half_set integer NOT NULL,
    id_line integer NOT NULL,
    id_protection_device integer NOT NULL,
    id_substation integer NOT NULL
);


ALTER TABLE public.protection_half_set OWNER TO postgres;

--
--TOC entry 237 (class 1259 OID 33310)
-- Name: protection_half_set_id_protection_half_set_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.protection_half_set_id_protection_half_set_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.protection_half_set_id_protection_half_set_seq OWNER TO postgres;

--
--TOC entry 5019 (class 0 OID 0)
-- Dependencies: 237
-- Name: protection_half_set_id_protection_half_set_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.protection_half_set_id_protection_half_set_seq OWNED BY public.protection_half_set.id_protection_half_set;


--
--TOC entry 252 (class 1259 OID 33560)
-- Name: sensitivity_analysis; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sensitivity_analysis(
    id_sensitivity integer NOT NULL,
    id_settings_calculation integer NOT NULL,
    id_fault_calculation integer NOT NULL,
    sensitivity_rate double precision NOT NULL,
    status character varying(255) NOT NULL
);


ALTER TABLE public.sensitivity_analysis OWNER TO postgres;

--
--TOC entry 251 (class 1259 OID 33559)
-- Name: sensitivity_analysis_id_sensitivity_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.sensitivity_analysis_id_sensitivity_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.sensitivity_analysis_id_sensitivity_seq OWNER TO postgres;

--
--TOC entry 5020 (class 0 OID 0)
-- Dependencies: 251
-- Name: sensitivity_analysis_id_sensitivity_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.sensitivity_analysis_id_sensitivity_seq OWNED BY public.sensitivity_analysis.id_sensitivity;


--
--TOC entry 250 (class 1259 OID 33536)
-- Name: settings_calculation; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.settings_calculation(
    id_settings_calculation integer NOT NULL,
    id_component integer NOT NULL,
    id_calculation integer NOT NULL,
    id_protection_half_set integer NOT NULL,
    result_value double precision NOT NULL,
    primary_value double precision NOT NULL,
    secondary_value double precision NOT NULL,
    calculation_factors jsonb
);


ALTER TABLE public.settings_calculation OWNER TO postgres;

--
--TOC entry 249 (class 1259 OID 33535)
-- Name: settings_calculation_id_settings_calculation_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.settings_calculation_id_settings_calculation_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.settings_calculation_id_settings_calculation_seq OWNER TO postgres;

--
--TOC entry 5021 (class 0 OID 0)
-- Dependencies: 249
-- Name: settings_calculation_id_settings_calculation_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.settings_calculation_id_settings_calculation_seq OWNED BY public.settings_calculation.id_settings_calculation;


--
--TOC entry 220 (class 1259 OID 33157)
-- Name: substation; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.substation(
    id_substation integer NOT NULL,
    dispatch_name character varying(100) NOT NULL,
    pf_name character varying(100) NOT NULL
);


ALTER TABLE public.substation OWNER TO postgres;

--
--TOC entry 219 (class 1259 OID 33156)
-- Name: substation_id_substation_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.substation_id_substation_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.substation_id_substation_seq OWNER TO postgres;

--
--TOC entry 5022 (class 0 OID 0)
-- Dependencies: 219
-- Name: substation_id_substation_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.substation_id_substation_seq OWNED BY public.substation.id_substation;


--
--TOC entry 4713 (class 2604 OID 33216)
-- Name: auth_group id_auth_group; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.auth_group ALTER COLUMN id_auth_group SET DEFAULT nextval('public.auth_group_id_auth_group_seq'::regclass);


--
--TOC entry 4714 (class 2604 OID 33225)
-- Name: auth_user id_auth_user; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.auth_user ALTER COLUMN id_auth_user SET DEFAULT nextval('public.auth_user_id_auth_user_seq'::regclass);


--
--TOC entry 4719 (class 2604 OID 33336)
-- Name: calculation id_calculation; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.calculation ALTER COLUMN id_calculation SET DEFAULT nextval('public.calculation_id_calculation_seq'::regclass);


--
--TOC entry 4710 (class 2604 OID 33171)
-- Name: coefficient_type id_coefficient_type; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.coefficient_type ALTER COLUMN id_coefficient_type SET DEFAULT nextval('public.coefficient_type_id_coefficient_type_seq'::regclass);


--
--TOC entry 4721 (class 2604 OID 33484)
-- Name: component id_component; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.component ALTER COLUMN id_component SET DEFAULT nextval('public.component_id_component_seq'::regclass);


--
--TOC entry 4720 (class 2604 OID 33355)
-- Name: fault_calculation id_fault_calculation; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.fault_calculation ALTER COLUMN id_fault_calculation SET DEFAULT nextval('public.fault_calculation_id_fault_calculation_seq'::regclass);


--
--TOC entry 4715 (class 2604 OID 33238)
-- Name: line id_line; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.line ALTER COLUMN id_line SET DEFAULT nextval('public.line_id_line_seq'::regclass);


--
--TOC entry 4716 (class 2604 OID 33254)
-- Name: line_branch id_branch; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.line_branch ALTER COLUMN id_branch SET DEFAULT nextval('public.line_branch_id_branch_seq'::regclass);


--
--TOC entry 4708 (class 2604 OID 33149)
-- Name: line_type id_line_type; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.line_type ALTER COLUMN id_line_type SET DEFAULT nextval('public.line_type_id_line_type_seq'::regclass);


--
--TOC entry 4712 (class 2604 OID 33202)
-- Name: manufacturer id_manufacturer; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.manufacturer ALTER COLUMN id_manufacturer SET DEFAULT nextval('public.manufacturer_id_manufacturer_seq'::regclass);


--
--TOC entry 4711 (class 2604 OID 33193)
-- Name: methodology_document id_methodology; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.methodology_document ALTER COLUMN id_methodology SET DEFAULT nextval('public.methodology_document_id_methodology_seq'::regclass);


--
--TOC entry 4722 (class 2604 OID 33500)
-- Name: protection_component_coefficient id_component_coefficient; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.protection_component_coefficient ALTER COLUMN id_component_coefficient SET DEFAULT nextval('public.protection_component_coefficient_id_component_coefficient_seq'::regclass);


--
--TOC entry 4717 (class 2604 OID 33275)
-- Name: protection_device id_device; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.protection_device ALTER COLUMN id_device SET DEFAULT nextval('public.protection_device_id_device_seq'::regclass);


--
--TOC entry 4723 (class 2604 OID 33519)
-- Name: protection_device_component id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.protection_device_component ALTER COLUMN id SET DEFAULT nextval('public.protection_device_component_id_seq'::regclass);


--
--TOC entry 4718 (class 2604 OID 33314)
-- Name: protection_half_set id_protection_half_set; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.protection_half_set ALTER COLUMN id_protection_half_set SET DEFAULT nextval('public.protection_half_set_id_protection_half_set_seq'::regclass);


--
--TOC entry 4725 (class 2604 OID 33563)
-- Name: sensitivity_analysis id_sensitivity; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sensitivity_analysis ALTER COLUMN id_sensitivity SET DEFAULT nextval('public.sensitivity_analysis_id_sensitivity_seq'::regclass);


--
--TOC entry 4724 (class 2604 OID 33539)
-- Name: settings_calculation id_settings_calculation; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.settings_calculation ALTER COLUMN id_settings_calculation SET DEFAULT nextval('public.settings_calculation_id_settings_calculation_seq'::regclass);


--
--TOC entry 4709 (class 2604 OID 33160)
-- Name: substation id_substation; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.substation ALTER COLUMN id_substation SET DEFAULT nextval('public.substation_id_substation_seq'::regclass);


--
--TOC entry 4975 (class 0 OID 33213)
-- Dependencies: 228
-- Data for Name: auth_group; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.auth_group(id_auth_group, name) FROM stdin;
\.


--
--TOC entry 4977 (class 0 OID 33222)
-- Dependencies: 230
-- Data for Name: auth_user; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.auth_user(id_auth_user, password, last_login, is_superuser, username, first_name, last_name, email, is_staff, is_active, data_joined) FROM stdin;
\.


--
--TOC entry 4987 (class 0 OID 33333)
-- Dependencies: 240
-- Data for Name: calculation; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.calculation(id_calculation, id_line, id_auth_user, calculation_number, calculation_date) FROM stdin;
\.


--
--TOC entry 4969 (class 0 OID 33168)
-- Dependencies: 222
-- Data for Name: coefficient_type; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.coefficient_type(id_coefficient_type, code, name, description) FROM stdin;
\.


--
--TOC entry 4991 (class 0 OID 33481)
-- Dependencies: 244
-- Data for Name: component; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.component(id_component, id_component_coefficient, is_active, description, setting_designation, name) FROM stdin;
\.


--
--TOC entry 4989 (class 0 OID 33352)
-- Dependencies: 242
-- Data for Name: fault_calculation; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.fault_calculation(id_fault_calculation, id_calculation_meta, id_protection_half_set, fault_type, fault_values, fault_location, network_topology) FROM stdin;
\.


--
--TOC entry 4979 (class 0 OID 33235)
-- Dependencies: 232
-- Data for Name: line; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.line(id_line, id_line_type, dispatch_name, pf_name, current_capacity, length, manual_ct_ratio, manual_vt_ratio, branch_count, is_offset_applied, zero_sequence_voltage, offset_coefficient) FROM stdin;
\.


--
--TOC entry 4981 (class 0 OID 33251)
-- Dependencies: 234
-- Data for Name: line_branch; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.line_branch(id_branch, id_line, id_substation, dispatch_name, pf_name, length, is_active) FROM stdin;
\.


--
--TOC entry 4965 (class 0 OID 33146)
-- Dependencies: 218
-- Data for Name: line_type; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.line_type(id_line_type, type_code, protection_recommendation) FROM stdin;
\.


--
--TOC entry 4973 (class 0 OID 33199)
-- Dependencies: 226
-- Data for Name: manufacturer; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.manufacturer(id_manufacturer, id_methodology, name) FROM stdin;
\.


--
--TOC entry 4971 (class 0 OID 33190)
-- Dependencies: 224
-- Data for Name: methodology_document; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.methodology_document(id_methodology, methodology_url, created_at, updated_at) FROM stdin;
\.


--
--TOC entry 4993 (class 0 OID 33497)
-- Dependencies: 246
-- Data for Name: protection_component_coefficient; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.protection_component_coefficient(id_component_coefficient, id_component, id_coefficient_type, default_value, min_value, max_value) FROM stdin;
\.


--
--TOC entry 4983 (class 0 OID 33272)
-- Dependencies: 236
-- Data for Name: protection_device; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.protection_device(id_device, id_manufacturer, device_model) FROM stdin;
\.


--
--TOC entry 4995 (class 0 OID 33516)
-- Dependencies: 248
-- Data for Name: protection_device_component; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.protection_device_component(id, id_protection_device, id_component) FROM stdin;
\.


--
--TOC entry 4985 (class 0 OID 33311)
-- Dependencies: 238
-- Data for Name: protection_half_set; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.protection_half_set(id_protection_half_set, id_line, id_protection_device, id_substation) FROM stdin;
\.


--
--TOC entry 4999 (class 0 OID 33560)
-- Dependencies: 252
-- Data for Name: sensitivity_analysis; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.sensitivity_analysis(id_sensitivity, id_settings_calculation, id_fault_calculation, sensitivity_rate, status) FROM stdin;
\.


--
--TOC entry 4997 (class 0 OID 33536)
-- Dependencies: 250
-- Data for Name: settings_calculation; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.settings_calculation(id_settings_calculation, id_component, id_calculation, id_protection_half_set, result_value, primary_value, secondary_value, calculation_factors) FROM stdin;
\.


--
--TOC entry 4967 (class 0 OID 33157)
-- Dependencies: 220
-- Data for Name: substation; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.substation(id_substation, dispatch_name, pf_name) FROM stdin;
\.


--
--TOC entry 5023 (class 0 OID 0)
-- Dependencies: 227
-- Name: auth_group_id_auth_group_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.auth_group_id_auth_group_seq', 1, false);


--
--TOC entry 5024 (class 0 OID 0)
-- Dependencies: 229
-- Name: auth_user_id_auth_user_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.auth_user_id_auth_user_seq', 1, false);


--
--TOC entry 5025 (class 0 OID 0)
-- Dependencies: 239
-- Name: calculation_id_calculation_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.calculation_id_calculation_seq', 1, false);


--
--TOC entry 5026 (class 0 OID 0)
-- Dependencies: 221
-- Name: coefficient_type_id_coefficient_type_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.coefficient_type_id_coefficient_type_seq', 1, false);


--
--TOC entry 5027 (class 0 OID 0)
-- Dependencies: 243
-- Name: component_id_component_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.component_id_component_seq', 1, false);


--
--TOC entry 5028 (class 0 OID 0)
-- Dependencies: 241
-- Name: fault_calculation_id_fault_calculation_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.fault_calculation_id_fault_calculation_seq', 1, false);


--
--TOC entry 5029 (class 0 OID 0)
-- Dependencies: 233
-- Name: line_branch_id_branch_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.line_branch_id_branch_seq', 1, false);


--
--TOC entry 5030 (class 0 OID 0)
-- Dependencies: 231
-- Name: line_id_line_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.line_id_line_seq', 1, false);


--
--TOC entry 5031 (class 0 OID 0)
-- Dependencies: 217
-- Name: line_type_id_line_type_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.line_type_id_line_type_seq', 1, false);


--
--TOC entry 5032 (class 0 OID 0)
-- Dependencies: 225
-- Name: manufacturer_id_manufacturer_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.manufacturer_id_manufacturer_seq', 1, false);


--
--TOC entry 5033 (class 0 OID 0)
-- Dependencies: 223
-- Name: methodology_document_id_methodology_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.methodology_document_id_methodology_seq', 1, false);


--
--TOC entry 5034 (class 0 OID 0)
-- Dependencies: 245
-- Name: protection_component_coefficient_id_component_coefficient_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.protection_component_coefficient_id_component_coefficient_seq', 1, false);


--
--TOC entry 5035 (class 0 OID 0)
-- Dependencies: 247
-- Name: protection_device_component_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.protection_device_component_id_seq', 1, false);


--
--TOC entry 5036 (class 0 OID 0)
-- Dependencies: 235
-- Name: protection_device_id_device_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.protection_device_id_device_seq', 1, false);


--
--TOC entry 5037 (class 0 OID 0)
-- Dependencies: 237
-- Name: protection_half_set_id_protection_half_set_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.protection_half_set_id_protection_half_set_seq', 1, false);


--
--TOC entry 5038 (class 0 OID 0)
-- Dependencies: 251
-- Name: sensitivity_analysis_id_sensitivity_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.sensitivity_analysis_id_sensitivity_seq', 1, false);


--
--TOC entry 5039 (class 0 OID 0)
-- Dependencies: 249
-- Name: settings_calculation_id_settings_calculation_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.settings_calculation_id_settings_calculation_seq', 1, false);


--
--TOC entry 5040 (class 0 OID 0)
-- Dependencies: 219
-- Name: substation_id_substation_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.substation_id_substation_seq', 1, false);


--
--TOC entry 4751 (class 2606 OID 33220)
-- Name: auth_group auth_group_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.auth_group
    ADD CONSTRAINT auth_group_name_key UNIQUE (name);


--
--TOC entry 4753 (class 2606 OID 33218)
-- Name: auth_group auth_group_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.auth_group
    ADD CONSTRAINT auth_group_pkey PRIMARY KEY (id_auth_group);


--
--TOC entry 4755 (class 2606 OID 33233)
-- Name: auth_user auth_user_email_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.auth_user
    ADD CONSTRAINT auth_user_email_key UNIQUE (email);


--
--TOC entry 4757 (class 2606 OID 33229)
-- Name: auth_user auth_user_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.auth_user
    ADD CONSTRAINT auth_user_pkey PRIMARY KEY (id_auth_user);


--
--TOC entry 4759 (class 2606 OID 33231)
-- Name: auth_user auth_user_username_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.auth_user
    ADD CONSTRAINT auth_user_username_key UNIQUE (username);


--
--TOC entry 4777 (class 2606 OID 33340)
-- Name: calculation calculation_calculation_number_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.calculation
    ADD CONSTRAINT calculation_calculation_number_key UNIQUE (calculation_number);


--
--TOC entry 4779 (class 2606 OID 33338)
-- Name: calculation calculation_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.calculation
    ADD CONSTRAINT calculation_pkey PRIMARY KEY (id_calculation);


--
--TOC entry 4737 (class 2606 OID 33177)
-- Name: coefficient_type coefficient_type_code_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.coefficient_type
    ADD CONSTRAINT coefficient_type_code_key UNIQUE (code);


--
--TOC entry 4739 (class 2606 OID 33179)
-- Name: coefficient_type coefficient_type_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.coefficient_type
    ADD CONSTRAINT coefficient_type_name_key UNIQUE (name);


--
--TOC entry 4741 (class 2606 OID 33175)
-- Name: coefficient_type coefficient_type_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.coefficient_type
    ADD CONSTRAINT coefficient_type_pkey PRIMARY KEY (id_coefficient_type);


--
--TOC entry 4783 (class 2606 OID 33490)
-- Name: component component_description_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.component
    ADD CONSTRAINT component_description_key UNIQUE (description);


--
--TOC entry 4785 (class 2606 OID 33494)
-- Name: component component_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.component
    ADD CONSTRAINT component_name_key UNIQUE (name);


--
--TOC entry 4787 (class 2606 OID 33488)
-- Name: component component_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.component
    ADD CONSTRAINT component_pkey PRIMARY KEY (id_component);


--
--TOC entry 4789 (class 2606 OID 33492)
-- Name: component component_setting_designation_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.component
    ADD CONSTRAINT component_setting_designation_key UNIQUE (setting_designation);


--
--TOC entry 4781 (class 2606 OID 33359)
-- Name: fault_calculation fault_calculation_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.fault_calculation
    ADD CONSTRAINT fault_calculation_pkey PRIMARY KEY (id_fault_calculation);


--
--TOC entry 4767 (class 2606 OID 33258)
-- Name: line_branch line_branch_dispatch_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.line_branch
    ADD CONSTRAINT line_branch_dispatch_name_key UNIQUE (dispatch_name);


--
--TOC entry 4769 (class 2606 OID 33260)
-- Name: line_branch line_branch_pf_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.line_branch
    ADD CONSTRAINT line_branch_pf_name_key UNIQUE (pf_name);


--
--TOC entry 4771 (class 2606 OID 33256)
-- Name: line_branch line_branch_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.line_branch
    ADD CONSTRAINT line_branch_pkey PRIMARY KEY (id_branch);


--
--TOC entry 4761 (class 2606 OID 33242)
-- Name: line line_dispatch_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.line
    ADD CONSTRAINT line_dispatch_name_key UNIQUE (dispatch_name);


--
--TOC entry 4763 (class 2606 OID 33244)
-- Name: line line_pf_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.line
    ADD CONSTRAINT line_pf_name_key UNIQUE (pf_name);


--
--TOC entry 4765 (class 2606 OID 33240)
-- Name: line line_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.line
    ADD CONSTRAINT line_pkey PRIMARY KEY (id_line);


--
--TOC entry 4727 (class 2606 OID 33153)
-- Name: line_type line_type_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.line_type
    ADD CONSTRAINT line_type_pkey PRIMARY KEY (id_line_type);


--
--TOC entry 4729 (class 2606 OID 33155)
-- Name: line_type line_type_type_code_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.line_type
    ADD CONSTRAINT line_type_type_code_key UNIQUE (type_code);


--
--TOC entry 4747 (class 2606 OID 33206)
-- Name: manufacturer manufacturer_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.manufacturer
    ADD CONSTRAINT manufacturer_name_key UNIQUE (name);


--
--TOC entry 4749 (class 2606 OID 33204)
-- Name: manufacturer manufacturer_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.manufacturer
    ADD CONSTRAINT manufacturer_pkey PRIMARY KEY (id_manufacturer);


--
--TOC entry 4743 (class 2606 OID 33197)
-- Name: methodology_document methodology_document_methodology_url_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.methodology_document
    ADD CONSTRAINT methodology_document_methodology_url_key UNIQUE (methodology_url);


--
--TOC entry 4745 (class 2606 OID 33195)
-- Name: methodology_document methodology_document_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.methodology_document
    ADD CONSTRAINT methodology_document_pkey PRIMARY KEY (id_methodology);


--
--TOC entry 4791 (class 2606 OID 33502)
-- Name: protection_component_coefficient protection_component_coefficient_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.protection_component_coefficient
    ADD CONSTRAINT protection_component_coefficient_pkey PRIMARY KEY (id_component_coefficient);


--
--TOC entry 4793 (class 2606 OID 33521)
-- Name: protection_device_component protection_device_component_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.protection_device_component
    ADD CONSTRAINT protection_device_component_pkey PRIMARY KEY (id);


--
--TOC entry 4773 (class 2606 OID 33277)
-- Name: protection_device protection_device_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.protection_device
    ADD CONSTRAINT protection_device_pkey PRIMARY KEY (id_device);


--
--TOC entry 4775 (class 2606 OID 33316)
-- Name: protection_half_set protection_half_set_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.protection_half_set
    ADD CONSTRAINT protection_half_set_pkey PRIMARY KEY (id_protection_half_set);


--
--TOC entry 4797 (class 2606 OID 33565)
-- Name: sensitivity_analysis sensitivity_analysis_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sensitivity_analysis
    ADD CONSTRAINT sensitivity_analysis_pkey PRIMARY KEY (id_sensitivity);


--
--TOC entry 4795 (class 2606 OID 33543)
-- Name: settings_calculation settings_calculation_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.settings_calculation
    ADD CONSTRAINT settings_calculation_pkey PRIMARY KEY (id_settings_calculation);


--
--TOC entry 4731 (class 2606 OID 33164)
-- Name: substation substation_dispatch_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.substation
    ADD CONSTRAINT substation_dispatch_name_key UNIQUE (dispatch_name);


--
--TOC entry 4733 (class 2606 OID 33166)
-- Name: substation substation_pf_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.substation
    ADD CONSTRAINT substation_pf_name_key UNIQUE (pf_name);


--
--TOC entry 4735 (class 2606 OID 33162)
-- Name: substation substation_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.substation
    ADD CONSTRAINT substation_pkey PRIMARY KEY (id_substation);


--
--TOC entry 4806 (class 2606 OID 33346)
-- Name: calculation calculation_id_auth_user_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.calculation
    ADD CONSTRAINT calculation_id_auth_user_fkey FOREIGN KEY (id_auth_user) REFERENCES public.auth_user(id_auth_user);


--
--TOC entry 4807 (class 2606 OID 33341)
-- Name: calculation calculation_id_line_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.calculation
    ADD CONSTRAINT calculation_id_line_fkey FOREIGN KEY (id_line) REFERENCES public.line(id_line);


--
--TOC entry 4808 (class 2606 OID 33360)
-- Name: fault_calculation fault_calculation_id_calculation_meta_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.fault_calculation
    ADD CONSTRAINT fault_calculation_id_calculation_meta_fkey FOREIGN KEY (id_calculation_meta) REFERENCES public.calculation(id_calculation);


--
--TOC entry 4809 (class 2606 OID 33365)
-- Name: fault_calculation fault_calculation_id_protection_half_set_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.fault_calculation
    ADD CONSTRAINT fault_calculation_id_protection_half_set_fkey FOREIGN KEY (id_protection_half_set) REFERENCES public.protection_half_set(id_protection_half_set);


--
--TOC entry 4800 (class 2606 OID 33261)
-- Name: line_branch line_branch_id_line_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.line_branch
    ADD CONSTRAINT line_branch_id_line_fkey FOREIGN KEY (id_line) REFERENCES public.line(id_line);


--
--TOC entry 4801 (class 2606 OID 33266)
-- Name: line_branch line_branch_id_substation_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.line_branch
    ADD CONSTRAINT line_branch_id_substation_fkey FOREIGN KEY (id_substation) REFERENCES public.substation(id_substation);


--
--TOC entry 4799 (class 2606 OID 33245)
-- Name: line line_id_line_type_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.line
    ADD CONSTRAINT line_id_line_type_fkey FOREIGN KEY (id_line_type) REFERENCES public.line_type(id_line_type);


--
--TOC entry 4798 (class 2606 OID 33207)
-- Name: manufacturer manufacturer_id_methodology_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.manufacturer
    ADD CONSTRAINT manufacturer_id_methodology_fkey FOREIGN KEY (id_methodology) REFERENCES public.methodology_document(id_methodology);


--
--TOC entry 4810 (class 2606 OID 33508)
-- Name: protection_component_coefficient protection_component_coefficient_id_coefficient_type_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.protection_component_coefficient
    ADD CONSTRAINT protection_component_coefficient_id_coefficient_type_fkey FOREIGN KEY (id_coefficient_type) REFERENCES public.coefficient_type(id_coefficient_type);


--
--TOC entry 4811 (class 2606 OID 33503)
-- Name: protection_component_coefficient protection_component_coefficient_id_component_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.protection_component_coefficient
    ADD CONSTRAINT protection_component_coefficient_id_component_fkey FOREIGN KEY (id_component) REFERENCES public.component(id_component);


--
--TOC entry 4812 (class 2606 OID 33527)
-- Name: protection_device_component protection_device_component_id_component_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.protection_device_component
    ADD CONSTRAINT protection_device_component_id_component_fkey FOREIGN KEY (id_component) REFERENCES public.component(id_component);


--
--TOC entry 4813 (class 2606 OID 33522)
-- Name: protection_device_component protection_device_component_id_protection_device_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.protection_device_component
    ADD CONSTRAINT protection_device_component_id_protection_device_fkey FOREIGN KEY (id_protection_device) REFERENCES public.protection_device(id_device);


--
--TOC entry 4802 (class 2606 OID 33278)
-- Name: protection_device protection_device_id_manufacturer_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.protection_device
    ADD CONSTRAINT protection_device_id_manufacturer_fkey FOREIGN KEY (id_manufacturer) REFERENCES public.manufacturer(id_manufacturer);


--
--TOC entry 4803 (class 2606 OID 33317)
-- Name: protection_half_set protection_half_set_id_line_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.protection_half_set
    ADD CONSTRAINT protection_half_set_id_line_fkey FOREIGN KEY (id_line) REFERENCES public.line(id_line);


--
--TOC entry 4804 (class 2606 OID 33322)
-- Name: protection_half_set protection_half_set_id_protection_device_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.protection_half_set
    ADD CONSTRAINT protection_half_set_id_protection_device_fkey FOREIGN KEY (id_protection_device) REFERENCES public.protection_device(id_device);


--
--TOC entry 4805 (class 2606 OID 33327)
-- Name: protection_half_set protection_half_set_id_substation_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.protection_half_set
    ADD CONSTRAINT protection_half_set_id_substation_fkey FOREIGN KEY (id_substation) REFERENCES public.substation(id_substation);


--
--TOC entry 4817 (class 2606 OID 33571)
-- Name: sensitivity_analysis sensitivity_analysis_id_fault_calculation_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sensitivity_analysis
    ADD CONSTRAINT sensitivity_analysis_id_fault_calculation_fkey FOREIGN KEY (id_fault_calculation) REFERENCES public.fault_calculation(id_fault_calculation);


--
--TOC entry 4818 (class 2606 OID 33566)
-- Name: sensitivity_analysis sensitivity_analysis_id_settings_calculation_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sensitivity_analysis
    ADD CONSTRAINT sensitivity_analysis_id_settings_calculation_fkey FOREIGN KEY (id_settings_calculation) REFERENCES public.settings_calculation(id_settings_calculation);


--
--TOC entry 4814 (class 2606 OID 33549)
-- Name: settings_calculation settings_calculation_id_calculation_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.settings_calculation
    ADD CONSTRAINT settings_calculation_id_calculation_fkey FOREIGN KEY (id_calculation) REFERENCES public.calculation(id_calculation);


--
--TOC entry 4815 (class 2606 OID 33544)
-- Name: settings_calculation settings_calculation_id_component_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.settings_calculation
    ADD CONSTRAINT settings_calculation_id_component_fkey FOREIGN KEY (id_component) REFERENCES public.component(id_component);


--
--TOC entry 4816 (class 2606 OID 33554)
-- Name: settings_calculation settings_calculation_id_protection_half_set_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.settings_calculation
    ADD CONSTRAINT settings_calculation_id_protection_half_set_fkey FOREIGN KEY (id_protection_half_set) REFERENCES public.protection_half_set(id_protection_half_set);


--Completed on 2025-10-28 16:47:37

--
-- PostgreSQL database dump complete
--


