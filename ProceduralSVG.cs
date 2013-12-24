using System;
using System.Collections.Generic;
using System.Text;

using Mogre;
using Math=Mogre.Math;

namespace Mogre_Procedural
{
public static class GlobalMembersProceduralSVG
{
		//! When exceptions are disabled by defining RAPIDXML_NO_EXCEPTIONS, 
		//! this function is called to notify user about the error.
		//! It must be defined by the user.
		//! <br><br>
		//! This function cannot return. If it does, the results are undefined.
		//! <br><br>
		//! A very simple definition might look like that:
		//! <pre>
		//! void %rapidxml::%parse_error_handler(const char *what, void *where)
		//! {
		//!     std::cout << "Parse error: " << what << "\n";
		//!     std::abort();
		//! }
		//! </pre>
		//! \param what Human readable description of the error.
		//! \param where Pointer to character data where error was detected.
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//	void parse_error_handler(string what, IntPtr where);

		///////////////////////////////////////////////////////////////////////
		// Parsing flags

		//! Parse flag instructing the parser to not create data nodes. 
		//! Text of first data node will still be placed in value of parent element, unless rapidxml::parse_no_element_values flag is also specified.
		//! Can be combined with other flags by use of | operator.
		//! <br><br>
		//! See xml_document::parse() function.
		public const int parse_no_data_nodes = 0x1;

		//! Parse flag instructing the parser to not use text of first data node as a value of parent element.
		//! Can be combined with other flags by use of | operator.
		//! Note that child data nodes of element node take precendence over its value when printing. 
		//! That is, if element has one or more child data nodes <em>and</em> a value, the value will be ignored.
		//! Use rapidxml::parse_no_data_nodes flag to prevent creation of data nodes if you want to manipulate data using values of elements.
		//! <br><br>
		//! See xml_document::parse() function.
		public const int parse_no_element_values = 0x2;

		//! Parse flag instructing the parser to not place zero terminators after strings in the source text.
		//! By default zero terminators are placed, modifying source text.
		//! Can be combined with other flags by use of | operator.
		//! <br><br>
		//! See xml_document::parse() function.
		public const int parse_no_string_terminators = 0x4;

		//! Parse flag instructing the parser to not translate entities in the source text.
		//! By default entities are translated, modifying source text.
		//! Can be combined with other flags by use of | operator.
		//! <br><br>
		//! See xml_document::parse() function.
		public const int parse_no_entity_translation = 0x8;

		//! Parse flag instructing the parser to disable UTF-8 handling and assume plain 8 bit characters.
		//! By default, UTF-8 handling is enabled.
		//! Can be combined with other flags by use of | operator.
		//! <br><br>
		//! See xml_document::parse() function.
		public const int parse_no_utf8 = 0x10;

		//! Parse flag instructing the parser to create XML declaration node.
		//! By default, declaration node is not created.
		//! Can be combined with other flags by use of | operator.
		//! <br><br>
		//! See xml_document::parse() function.
		public const int parse_declaration_node = 0x20;

		//! Parse flag instructing the parser to create comments nodes.
		//! By default, comment nodes are not created.
		//! Can be combined with other flags by use of | operator.
		//! <br><br>
		//! See xml_document::parse() function.
		public const int parse_comment_nodes = 0x40;

		//! Parse flag instructing the parser to create DOCTYPE node.
		//! By default, doctype node is not created.
		//! Although W3C specification allows at most one DOCTYPE node, RapidXml will silently accept documents with more than one.
		//! Can be combined with other flags by use of | operator.
		//! <br><br>
		//! See xml_document::parse() function.
		public const int parse_doctype_node = 0x80;

		//! Parse flag instructing the parser to create PI nodes.
		//! By default, PI nodes are not created.
		//! Can be combined with other flags by use of | operator.
		//! <br><br>
		//! See xml_document::parse() function.
		public const int parse_pi_nodes = 0x100;

		//! Parse flag instructing the parser to validate closing tag names. 
		//! If not set, name inside closing tag is irrelevant to the parser.
		//! By default, closing tags are not validated.
		//! Can be combined with other flags by use of | operator.
		//! <br><br>
		//! See xml_document::parse() function.
		public const int parse_validate_closing_tags = 0x200;

		//! Parse flag instructing the parser to trim all leading and trailing whitespace of data nodes.
		//! By default, whitespace is not trimmed. 
		//! This flag does not cause the parser to modify source text.
		//! Can be combined with other flags by use of | operator.
		//! <br><br>
		//! See xml_document::parse() function.
		public const int parse_trim_whitespace = 0x400;

		//! Parse flag instructing the parser to condense all whitespace runs of data nodes to a single space character.
		//! Trimming of leading and trailing whitespace of data is controlled by rapidxml::parse_trim_whitespace flag.
		//! By default, whitespace is not normalized. 
		//! If this flag is specified, source text will be modified.
		//! Can be combined with other flags by use of | operator.
		//! <br><br>
		//! See xml_document::parse() function.
		public const int parse_normalize_whitespace = 0x800;

		// Compound flags

		//! Parse flags which represent default behaviour of the parser. 
		//! This is always equal to 0, so that all other flags can be simply ored together.
		//! Normally there is no need to inconveniently disable flags by anding with their negated (~) values.
		//! This also means that meaning of each flag is a <i>negation</i> of the default setting. 
		//! For example, if flag name is rapidxml::parse_no_utf8, it means that utf-8 is <i>enabled</i> by default,
		//! and using the flag will disable it.
		//! <br><br>
		//! See xml_document::parse() function.
		public const int parse_default = 0;

		//! A combination of parse flags that forbids any modifications of the source text. 
		//! This also results in faster parsing. However, note that the following will occur:
		//! <ul>
		//! <li>names and values of nodes will not be zero terminated, you have to use xml_base::name_size() and xml_base::value_size() functions to determine where name and value ends</li>
		//! <li>entities will not be translated</li>
		//! <li>whitespace will not be normalized</li>
		//! </ul>
		//! See xml_document::parse() function.
		public const int parse_non_destructive = parse_no_string_terminators | parse_no_entity_translation;

		//! A combination of parse flags resulting in fastest possible parsing, without sacrificing important data.
		//! <br><br>
		//! See xml_document::parse() function.
		public const int parse_fastest = parse_non_destructive | parse_no_data_nodes;

		//! A combination of parse flags resulting in largest amount of data being extracted. 
		//! This usually results in slowest parsing.
		//! <br><br>
		//! See xml_document::parse() function.
		public const int parse_full = parse_declaration_node | parse_comment_nodes | parse_doctype_node | parse_pi_nodes | parse_validate_closing_tags;

			// Find length of the string
			public static std.int measure<Ch>(Ch p)
			{
//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on this variable, so pointers on this variable are left unchanged.
				const Ch *tmp = p;
				while (*tmp)
					++tmp;
				return tmp - p;
			}
//C++ TO C# CONVERTER TODO TASK: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Ch>

			// Compare strings for equality
			public static bool compare<Ch>(Ch p1, std.int size1, Ch p2, std.int size2, bool case_sensitive)
			{
				if (size1 != size2)
					return false;
				if (case_sensitive)
				{
					for (const Ch end = p1 + size1; p1 < end; ++p1, ++p2)
						if ( p1 != p2)
							return false;
				}
				else
				{
					for (const Ch end = p1 + size1; p1 < end; ++p1, ++p2)
						if (lookup_tables<0>.lookup_upcase[(byte)( p1)] != lookup_tables<0>.lookup_upcase[(byte)( p2)])
							return false;
				}
				return true;
			}

			// Whitespace (space \n \r \t)
			public static readonly byte[] lookup_tables<Dummy>.lookup_whitespace = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Dummy>
			  // 0   1   2   3   4   5   6   7   8   9   A   B   C   D   E   F

			// Node name (anything but space \n \r \t / > ? \0)
			public static readonly byte[] lookup_tables<Dummy>.lookup_node_name = { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Dummy>
			  // 0   1   2   3   4   5   6   7   8   9   A   B   C   D   E   F

			// Text (i.e. PCDATA) (anything but < \0)
			public static readonly byte[] lookup_tables<Dummy>.lookup_text = { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Dummy>
			  // 0   1   2   3   4   5   6   7   8   9   A   B   C   D   E   F

			// Text (i.e. PCDATA) that does not require processing when ws normalization is disabled 
			// (anything but < \0 &)
			public static readonly byte[] lookup_tables<Dummy>.lookup_text_pure_no_ws = { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Dummy>
			  // 0   1   2   3   4   5   6   7   8   9   A   B   C   D   E   F

			// Text (i.e. PCDATA) that does not require processing when ws normalizationis is enabled
			// (anything but < \0 & space \n \r \t)
			public static readonly byte[] lookup_tables<Dummy>.lookup_text_pure_with_ws = { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Dummy>
			  // 0   1   2   3   4   5   6   7   8   9   A   B   C   D   E   F

			// Attribute name (anything but space \n \r \t / < > = ? ! \0)
			public static readonly byte[] lookup_tables<Dummy>.lookup_attribute_name = { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Dummy>
			  // 0   1   2   3   4   5   6   7   8   9   A   B   C   D   E   F

			// Attribute data with single quote (anything but ' \0)
			public static readonly byte[] lookup_tables<Dummy>.lookup_attribute_data_1 = { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Dummy>
			  // 0   1   2   3   4   5   6   7   8   9   A   B   C   D   E   F

			// Attribute data with single quote that does not require processing (anything but ' \0 &)
			public static readonly byte[] lookup_tables<Dummy>.lookup_attribute_data_1_pure = { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Dummy>
			  // 0   1   2   3   4   5   6   7   8   9   A   B   C   D   E   F

			// Attribute data with double quote (anything but " \0)
			public static readonly byte[] lookup_tables<Dummy>.lookup_attribute_data_2 = { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Dummy>
			  // 0   1   2   3   4   5   6   7   8   9   A   B   C   D   E   F

			// Attribute data with double quote that does not require processing (anything but " \0 &)
			public static readonly byte[] lookup_tables<Dummy>.lookup_attribute_data_2_pure = { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Dummy>
			  // 0   1   2   3   4   5   6   7   8   9   A   B   C   D   E   F

			// Digits (dec and hex, 255 denotes end of numeric character reference)
			public static readonly byte[] lookup_tables<Dummy>.lookup_digits = { 255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255, 255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255, 255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9,255,255,255,255,255,255, 255, 10, 11, 12, 13, 14, 15,255,255,255,255,255,255,255,255,255, 255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255, 255, 10, 11, 12, 13, 14, 15,255,255,255,255,255,255,255,255,255, 255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255, 255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255, 255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255, 255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255, 255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255, 255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255, 255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255, 255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255, 255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255 };
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Dummy>
			  // 0   1   2   3   4   5   6   7   8   9   A   B   C   D   E   F

			// Upper case conversion
			public static readonly byte[] lookup_tables<Dummy>.lookup_upcase = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 123,124,125,126,127, 128,129,130,131,132,133,134,135,136,137,138,139,140,141,142,143, 144,145,146,147,148,149,150,151,152,153,154,155,156,157,158,159, 160,161,162,163,164,165,166,167,168,169,170,171,172,173,174,175, 176,177,178,179,180,181,182,183,184,185,186,187,188,189,190,191, 192,193,194,195,196,197,198,199,200,201,202,203,204,205,206,207, 208,209,210,211,212,213,214,215,216,217,218,219,220,221,222,223, 224,225,226,227,228,229,230,231,232,233,234,235,236,237,238,239, 240,241,242,243,244,245,246,247,248,249,250,251,252,253,254,255 };
	public static void SvgLoader.parseSvgFile<int Dummy>(ref MultiShape @out, string fileName, string groupName, int segmentsNumber)
	{
		mNumSeg = segmentsNumber;

		rapidxml.xml_document<> XMLDoc = new rapidxml.xml_document<>(); // character type defaults to char
		SharedPtr<DataStream> stream = ResourceGroupManager.getSingleton().openResource(fileName, groupName);
		sbyte svg = stream.getAsString().c_str();
		XMLDoc.parse<0>(svg);

		rapidxml.xml_node<> pXmlRoot = XMLDoc.first_node("svg");
		if (pXmlRoot == null)
			return;
		rapidxml.xml_node<> pXmlChildNode = pXmlRoot.first_node();
		while (pXmlChildNode != null)
		{
			parseChildNode(@out, pXmlChildNode);
			pXmlChildNode = pXmlChildNode.next_sibling();
		}
	}

	//-----------------------------------------------------------------------
	public static void SvgLoader.parseChildNode(ref MultiShape @out, rapidxml.xml_node<> pChild)
	{
		string name = pChild.name();
		if (name.Length > 3)
		{
//C++ TO C# CONVERTER TODO TASK: The c_str method is not converted to C#:
			if (strcasecmp(name.c_str(), "rect") == 0)
				parseRect(@out, pChild);
//C++ TO C# CONVERTER TODO TASK: The c_str method is not converted to C#:
			else if (strcasecmp(name.c_str(), "circle") == 0)
				parseCircle(@out, pChild);
//C++ TO C# CONVERTER TODO TASK: The c_str method is not converted to C#:
			else if (strcasecmp(name.c_str(), "ellipse") == 0)
				parseEllipse(@out, pChild);
//C++ TO C# CONVERTER TODO TASK: The c_str method is not converted to C#:
			else if (strcasecmp(name.c_str(), "polygon") == 0 || strcasecmp(name.c_str(), "polyline") == 0)
				parsePolygon(@out, pChild);
//C++ TO C# CONVERTER TODO TASK: The c_str method is not converted to C#:
			else if (strcasecmp(name.c_str(), "path") == 0)
				parsePath(@out, pChild); // svg path is a shape
		}

		rapidxml.xml_node<> pSubChildNode = pChild.first_node();
		while (pSubChildNode != null)
		{
			parseChildNode(@out, pSubChildNode);
			pSubChildNode = pSubChildNode.next_sibling();
		}
	}

	//-----------------------------------------------------------------------
	public static void SvgLoader.parseRect(ref MultiShape @out, rapidxml.xml_node<> pRectNode)
	{
		float width = getAttribReal(pRectNode, "width");
		float height = getAttribReal(pRectNode, "height");
		if (width <= 0.0f || height <= 0.0f)
			return;
		Shape s = new RectangleShape().setHeight(height).setWidth(width).realizeShape();
	//	if(pRectNode->first_attribute("id"))
		//	ss.id = pRectNode->first_attribute("id")->value();
		Vector2 position = new Vector2();
		position.x = getAttribReal(pRectNode, "x");
		position.y = getAttribReal(pRectNode, "y");
		// Our rectangle are centered, but svg rectangles are defined by their corners
		position += .5f *new Vector2(width, height);
		Vector2 trans = getAttribTranslate(pRectNode);
		position += trans;
		s.translate(position);

		@out.addShape(s);
	}

	//-----------------------------------------------------------------------
	public static void SvgLoader.parseCircle(ref MultiShape @out, rapidxml.xml_node<> pCircleNode)
	{
		float r = getAttribReal(pCircleNode, "r");
		if (r <= 0.0f)
			return;
		Shape s = new CircleShape().setNumSeg(mNumSeg).setRadius(r).realizeShape();
	//	if(pCircleNode->first_attribute("id"))
		//	ss.id = pCircleNode->first_attribute("id")->value();
		Vector2 position = new Vector2();
		position.x = getAttribReal(pCircleNode, "cx");
		position.y = getAttribReal(pCircleNode, "cy");
		Vector2 trans = getAttribTranslate(pCircleNode);
		position += trans;
		s.translate(position);
		@out.addShape(s);
	}

	//-----------------------------------------------------------------------
	public static void SvgLoader.parseEllipse(ref MultiShape @out, rapidxml.xml_node<> pEllipseNode)
	{
		float rx = getAttribReal(pEllipseNode, "rx");
		float ry = getAttribReal(pEllipseNode, "ry");
		if (rx <= 0.0f || ry <= 0.0f)
			return;
		Shape s = new EllipseShape().setNumSeg(mNumSeg).setRadiusX(rx).setRadiusY(ry).realizeShape();
	//	if(pEllipseNode->first_attribute("id"))
		//	ss.id = pEllipseNode->first_attribute("id")->value();
		Vector2 position = new Vector2();
		position.x = getAttribReal(pEllipseNode, "cx");
		position.y = getAttribReal(pEllipseNode, "cy");
		Vector2 trans = getAttribTranslate(pEllipseNode);
		position += trans;
		s.translate(position);
		@out.addShape(s);
	}

	//-----------------------------------------------------------------------
	public static void SvgLoader.parsePolygon(ref MultiShape @out, rapidxml.xml_node<> pPolygonNode)
	{
		if (pPolygonNode.first_attribute("points"))
		{
			if (pPolygonNode.first_attribute("points").value_size() < 3)
				return;
			string temp = xtrim(pPolygonNode.first_attribute("points").@value());
			List<string> pts = split(temp, (string)(" "));
			if (pts.Count == 0)
				return;
			Shape s = new Shape();
			for (int i = 0; i < pts.Count - 1; i+=2)
				s.addPoint(StringConverter.parseReal(pts[i + 0]), StringConverter.parseReal(pts[i + 1]));
			if (s.getPoints().size() == 0)
				return;
			s.close();
	//		if(pPolygonNode->first_attribute("id"))
			//		ss.id = pPolygonNode->first_attribute("id")->value();
			s.translate(getAttribTranslate(pPolygonNode));
			@out.addShape(s);
		}
	}
	//-----------------------------------------------------------------------
	public static void SvgLoader.parsePath(ref MultiShape @out, rapidxml.xml_node<> pPathNode)
	{
		if (pPathNode.first_attribute("d"))
		{
			string temp = xtrim(pPathNode.first_attribute("d").@value()," .-0123456789mMlLhHvVcCsSqQtTaAzZ");
			List<string> parts = split(temp, (string)(" "));
			for (int i = 0; i < parts.Count; i++)
				if (parts[i].size() > 1 && !(parts[i][0] == '-' || ('0' <= parts[i][0] && parts[i][0] <= '9')))
				{
//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent to the STL vector 'insert' method in C#:
					parts.insert(parts.GetEnumerator() + i + 1, parts[i].c_str() + 1);
					parts[i].erase(1, parts[i].size());
				}

			SvgLoaderPath sp = new SvgLoaderPath(parts, mNumSeg);
			if (!sp.isValid())
				return;
			Shape ss = sp.getSvgShape();
			Vector2 line = ss.getPoint(1) - ss.getPoint(0);
			float deg = line.angleBetween(ss.getPoint(2) - ss.getPoint(0)).valueDegrees();
			if ((0 <= deg && deg <= 180.0f) || (-180.0f <= deg && deg <= 0))
				ss.setOutSide(Side.SIDE_LEFT);
			else
				ss.setOutSide(Side.SIDE_RIGHT);

			//if(pPathNode->first_attribute("id"))
			//	ss.id = pPathNode->first_attribute("id")->value();
			ss.translate(getAttribTranslate(pPathNode));
			@out.addShape(ss);
		}
	}
	//-----------------------------------------------------------------------
	public static float SvgLoader.getAttribReal(rapidxml.xml_node<> pNode, string attrib, float defaultValue)
	{
//C++ TO C# CONVERTER TODO TASK: The c_str method is not converted to C#:
		if (pNode.first_attribute(attrib.c_str()))
		{
//C++ TO C# CONVERTER TODO TASK: The c_str method is not converted to C#:
			int len = pNode.first_attribute(attrib.c_str()).value_size();
			if (len == 0)
				return defaultValue;
			// remove units
			string tmp = new sbyte[len + 1];
//C++ TO C# CONVERTER TODO TASK: The c_str method is not converted to C#:
			tmp = pNode.first_attribute(attrib.c_str()).@value();
			for (int i = 0; i <= len; i++)
				if (!(tmp[i] == '.' || ('0' <= tmp[i] && tmp[i] <= '9')))
				{
					tmp = tmp.Substring(0, i);
					break;
				}
			// convert
			float retVal = StringConverter.parseReal(tmp);
			tmp = null;
			return retVal;
		}
		else
			return defaultValue;
	}

	//-----------------------------------------------------------------------
	public static Vector2 SvgLoader.getAttribTranslate(rapidxml.xml_node<> pNode)
	{
		if (pNode.first_attribute("transform"))
		{
			string temp = pNode.first_attribute("transform").@value();
			int begin = temp.IndexOf("translate(");
			if (begin ==string.npos)
				return Vector2.ZERO;
			begin+=10;
			int end = temp.IndexOf(")", begin);
			if (end == string.npos)
				return Vector2.ZERO;
			string temp2 = temp.Substring(begin, end-begin);
//C++ TO C# CONVERTER TODO TASK: The c_str method is not converted to C#:
			List<string> parts = split(xtrim(temp2.c_str()), (string)(" "));
			if (parts.Count == 2)
				return new Vector2(StringConverter.parseReal(parts[0]), StringConverter.parseReal(parts[1]));
			else
				return Vector2.ZERO;
		}
		else
			return Vector2.ZERO;
	}

	//-----------------------------------------------------------------------
	public static List<string> SvgLoader.split(string str, string delimiters, bool removeEmpty)
	{
		List<string> tokens = new List<string>();
		string.size_type delimPos = 0;
		string.size_type tokenPos = 0;
		string.size_type pos = 0;

		if (string.IsNullOrEmpty(str))
			return tokens;
		while (true)
		{
			delimPos = str.IndexOfAny(delimiters.ToCharArray(), pos);
//C++ TO C# CONVERTER TODO TASK: The find_first_not_of method is not converted to C#:
			tokenPos = str.find_first_not_of(delimiters, pos);

			if (string.npos != delimPos)
			{
				if (string.npos != tokenPos)
				{
					if (tokenPos < delimPos)
						tokens.Add(str.Substring(pos,delimPos-pos));
					else
					{
						if (!removeEmpty)
							tokens.Add("");
					}
				}
				else
				{
					if (!removeEmpty)
						tokens.Add("");
				}
				pos = delimPos+1;
			}
			else
			{
				if (string.npos != tokenPos)
					tokens.Add(str.Substring(pos));
				else
				{
					if (!removeEmpty)
						tokens.Add("");
				}
				break;
			}
		}
		return tokens;
	}

	//-----------------------------------------------------------------------
	public static string SvgLoader.xtrim(string val, string achar, sbyte rchar)
	{
		if (val == null)
			return string();
		int len = val.Length;
		string tmp = new sbyte[len + 1];
		tmp = val;
		tmp = tmp.Substring(0, len);
		for (int i = 0; i < len; i++)
		{
			bool valid = false;
			for (uint j = 0; j < achar.Length; j++)
			{
				valid = (tmp[i] == achar[j]);
				if (valid)
					break;
			}
			if (!valid)
				tmp = StringHelper.ChangeCharacter(tmp, i, rchar);
		}
		string temp = tmp;
		tmp = null;
		return temp;
	}

	//-----------------------------------------------------------------------
	public static SvgLoader.SvgLoaderPath.SvgLoaderPath(List<string> p, uint ns)
	{
		parts = p;
		mNumSeg = ns;
		px = 0.0f;
		py = 0.0f;
		index = 0;
		sbyte lastCmd = 0;

		while (index < p.Count)
		{
			try
			{
				sbyte newCmd = parts[index][0];
				bool next = true;
				if (lastCmd != newCmd && newCmd != '.' && newCmd != '-' && (newCmd < '0' || newCmd > '9') && curve.size() > 3 && ((lastCmd =='c' || lastCmd == 'C') && (newCmd =='s' || newCmd == 'S') || (lastCmd =='q' || lastCmd == 'Q') && (newCmd =='t' || newCmd == 'T')))
				{
					// finish curve
					finishCurve(lastCmd);
				}
				switch (newCmd)
				{
				case 'l':
					parseLineTo(true, next);
					break;
				case 'L':
					parseLineTo(false, next);
					break;
				case 'm':
					parseMoveTo(true, next);
					newCmd = (sbyte)'l';
					break;
				case 'M':
					parseMoveTo(false, next);
					newCmd = (sbyte)'L';
					break;
				case 'h':
					parseHLineTo(true, next);
					break;
				case 'H':
					parseHLineTo(false, next);
					break;
				case 'v':
					parseVLineTo(true, next);
					break;
				case 'V':
					parseVLineTo(false, next);
					break;
				case 'c':
					curve.push_back(point);
					parseCurveCTo(true, next);
					break;
				case 'C':
					curve.push_back(point);
					parseCurveCTo(false, next);
					break;
				case 's':
					parseCurveSTo(true, next);
					break;
				case 'S':
					parseCurveSTo(false, next);
					break;
				case 'q':
					curve.push_back(point);
					parseCurveQTo(true, next);
					break;
				case 'Q':
					curve.push_back(point);
					parseCurveQTo(false, next);
					break;
				case 't':
					parseCurveTTo(true, next);
					break;
				case 'T':
					parseCurveTTo(false, next);
					break;
				case 'a':
					parseArcTo(true, next);
					break;
				case 'A':
					parseArcTo(false, next);
					break;
				case 'z':
				case 'Z':
					shape.close();
					index++;
					break;
				default:
					newCmd = lastCmd;
					next = false;
					switch (lastCmd)
					{
					case 'l':
						parseLineTo(true, next);
						break;
					case 'L':
						parseLineTo(false, next);
						break;
					case 'm':
						parseMoveTo(true, next);
						break;
					case 'M':
						parseMoveTo(false, next);
						break;
					case 'h':
						parseHLineTo(true, next);
						break;
					case 'H':
						parseHLineTo(false, next);
						break;
					case 'v':
						parseVLineTo(true, next);
						break;
					case 'V':
						parseVLineTo(false, next);
						break;
					case 'c':
						parseCurveCTo(true, next);
						break;
					case 'C':
						parseCurveCTo(false, next);
						break;
					case 's':
						parseCurveSTo(true, next);
						break;
					case 'S':
						parseCurveSTo(false, next);
						break;
					case 'q':
						parseCurveQTo(true, next);
						break;
					case 'Q':
						parseCurveQTo(false, next);
						break;
					case 't':
						parseCurveTTo(true, next);
						break;
					case 'T':
						parseCurveTTo(false, next);
						break;
					case 'a':
						parseArcTo(true, next);
						break;
					case 'A':
						parseArcTo(false, next);
						break;

					default:
						break;
					}
					break;
				}
				lastCmd = newCmd;
			}
			catch
			{
			}
		}
		if (curve.size() > 0)
			finishCurve(lastCmd);
	}

	//-----------------------------------------------------------------------
	public static void SvgLoader.SvgLoaderPath.parseArcTo(bool rel, bool next)
	{
		if (next)
			index++;
		float rx = 0.0f;
		if (!parseReal(rx))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseCurveSTo", __FILE__, __LINE__);
			;
		float ry = 0.0f;
		if (!parseReal(ry))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseCurveSTo", __FILE__, __LINE__);
			;
		float x_axis_rotation = 0.0f;
		if (!parseReal(x_axis_rotation))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseCurveSTo", __FILE__, __LINE__);
			;
		float large_arc_flag = 0.0f;
		if (!parseReal(large_arc_flag))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseCurveSTo", __FILE__, __LINE__);
			;
		float sweep_flag = 0.0f;
		if (!parseReal(sweep_flag))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseCurveSTo", __FILE__, __LINE__);
			;
		float x = 0.0f;
		if (!parseReal(x))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseCurveSTo", __FILE__, __LINE__);
			;
		float y = 0.0f;
		if (!parseReal(y))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseCurveSTo", __FILE__, __LINE__);
			;

		float RadiansPerDegree = Math.PI / 180.0f;
		float epx = rel ? point.x + x : x;
		float epy = rel ? point.y + y : y;
		bool largeArc = (large_arc_flag > 0);
		bool clockwise = (sweep_flag > 0);

		if (epx == point.x && epy == point.y)
			return;

		if (rx == 0.0f && ry == 0.0f)
		{
			point = new Vector2(epx, epy);
			shape.addPoint(point);
			return;
		}

		float sinPhi = Math.Sin(x_axis_rotation * RadiansPerDegree);
		float cosPhi = Math.Cos(x_axis_rotation * RadiansPerDegree);

		float x1dash = cosPhi * (point.x - epx) / 2.0f + sinPhi * (point.y - epy) / 2.0f;
		float y1dash = -sinPhi * (point.x - epx) / 2.0f + cosPhi * (point.y - epy) / 2.0f;

		float root = 0f;
		float numerator = rx * rx * ry * ry - rx * rx * y1dash * y1dash - ry * ry * x1dash * x1dash;

		if (numerator < 0.0)
		{
			float s = (float)Math.Sqrt(1.0f - numerator / (rx * rx * ry * ry));

			rx *= s;
			ry *= s;
			root = 0.0;
		}
		else
		{
			root = ((largeArc && clockwise) || (!largeArc && !clockwise) ? -1.0f : 1.0f) * Math.Sqrt(numerator / (rx * rx * y1dash * y1dash + ry * ry * x1dash * x1dash));
		}

		float cxdash = root * rx * y1dash / ry;
		float cydash = -root * ry * x1dash / rx;

		float cx = cosPhi * cxdash - sinPhi * cydash + (point.x + epx) / 2.0f;
		float cy = sinPhi * cxdash + cosPhi * cydash + (point.y + epy) / 2.0f;

		float theta1 = CalculateVectorAngle(1.0, 0.0, (x1dash - cxdash) / rx, (y1dash - cydash) / ry);
		float dtheta = CalculateVectorAngle((x1dash - cxdash) / rx, (y1dash - cydash) / ry, (-x1dash - cxdash) / rx, (-y1dash - cydash) / ry);

		if (!clockwise && dtheta > 0)
			dtheta -= 2.0f * Math.PI;
		else if (clockwise && dtheta < 0)
			dtheta += 2.0f * Math.PI;

		int segments = (int)Math.Ceiling((double)Math.Abs(dtheta / (Math.PI / 2.0f)));
		float delta = dtheta / segments;
		float t = 8.0f / 3.0f * Math.Sin(delta / 4.0f) * Math.Sin(delta / 4.0f) / Math.Sin(delta / 2.0f);

		float startX = point.x;
		float startY = point.y;

		BezierCurve2 bezier = new BezierCurve2();
		bezier.addPoint(startX, startY);
		for (int i = 0; i < segments; ++i)
		{
			float cosTheta1 = Math.Cos(theta1);
			float sinTheta1 = Math.Sin(theta1);
			float theta2 = theta1 + delta;
			float cosTheta2 = Math.Cos(theta2);
			float sinTheta2 = Math.Sin(theta2);

			float endpointX = cosPhi * rx * cosTheta2 - sinPhi * ry * sinTheta2 + cx;
			float endpointY = sinPhi * rx * cosTheta2 + cosPhi * ry * sinTheta2 + cy;

			float dx1 = t * (-cosPhi * rx * sinTheta1 - sinPhi * ry * cosTheta1);
			float dy1 = t * (-sinPhi * rx * sinTheta1 + cosPhi * ry * cosTheta1);

			float dxe = t * (cosPhi * rx * sinTheta2 + sinPhi * ry * cosTheta2);
			float dye = t * (sinPhi * rx * sinTheta2 - cosPhi * ry * cosTheta2);

			bezier.addPoint(startX + dx1, startY + dy1);
			bezier.addPoint(endpointX + dxe, endpointY + dye);

			theta1 = theta2;
			startX = endpointX;
			startY = endpointY;
		}
		point = new Vector2(epx, epy);
		bezier.addPoint(point);
		bezier.setNumSeg(mNumSeg);
		List<Vector2> pointList = bezier.realizeShape().getPoints();
		Vector2 lp = shape.getPoint(shape.getPoints().size() - 1);
		for (List<Vector2>.Enumerator iter = pointList.GetEnumerator(); iter.MoveNext(); iter++)
		{
			if (iter == pointList.GetEnumerator())
			{
				if (iter.Current != lp)
					shape.addPoint(iter.Current);
			}
			else
				shape.addPoint(iter.Current);
		}
	}
	//-----------------------------------------------------------------------
	public static void SvgLoader.SvgLoaderPath.finishCurve(sbyte lc)
	{
		int n;
		if (lc == 'c' || lc == 'C' || lc == 's' || lc == 'S')
			n = 3;
		else if (lc == 'q' || lc == 'Q' || lc == 't' || lc == 'T')
			n = 2;
		else
			n = curve.size() - 1;

		for (int i = 0; i < curve.size(); i += n)
		{
			if (i + 3 >= curve.size())
				break;
			BezierCurve2 bc2 = new BezierCurve2();
			bc2.setNumSeg(mNumSeg);
			bc2.addPoint(curve[i + 0]);
			bc2.addPoint(curve[i + 1]);
			bc2.addPoint(curve[i + 2]);
			bc2.addPoint(curve[i + 3]);
			Shape bc2shape = bc2.realizeShape();
			Vector2 lp = shape.getPoint(shape.getPoints().size() - 1);
			for (List<Vector2>.Enumerator iter = bc2shape.getPoints().begin(); iter != bc2shape.getPoints().end(); iter++)
			{
				if (iter == bc2shape.getPoints().begin())
				{
					if (iter.Current != lp)
						shape.addPoint(iter.Current);
				}
				else
					shape.addPoint(iter.Current);
			}
		}
		curve.clear();
	}
	//-----------------------------------------------------------------------
	public static void SvgLoader.SvgLoaderPath.parseCurveSTo(bool rel, bool next)
	{
		if (next)
			index++;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: Vector2 offset = Vector2::ZERO;
		Vector2 offset = new Vector2(Vector2.ZERO);
		if (rel)
			offset = point;

		float x1 = point.x;
		float y1 = point.y;
		if (curve.size() > 2)
		{
			Vector2 mirror = curve[curve.size() - 2];
			Vector2 diff = mirror - point;
			x1 = -1.0f * diff.x + point.x;
			y1 = -1.0f * diff.y + point.y;
		}
		float x2 = 0.0f;
		if (!parseReal(x2))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseCurveSTo", __FILE__, __LINE__);
			;
		float y2 = 0.0f;
		if (!parseReal(y2))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseCurveSTo", __FILE__, __LINE__);
			;
		float x = 0.0f;
		if (!parseReal(x))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseCurveSTo", __FILE__, __LINE__);
			;
		float y = 0.0f;
		if (!parseReal(y))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseCurveSTo", __FILE__, __LINE__);
			;
		curve.push_back(new Vector2(x1, y1) + offset);
		curve.push_back(new Vector2(x2, y2) + offset);
		point = new Vector2(x, y) + offset;
		curve.push_back(point);
	}
	//-----------------------------------------------------------------------
	public static void SvgLoader.SvgLoaderPath.parseCurveQTo(bool rel, bool next)
	{
		if (next)
			index++;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: Vector2 offset = Vector2::ZERO;
		Vector2 offset = new Vector2(Vector2.ZERO);
		if (rel)
			offset = point;

		float x1 = 0.0f;
		if (!parseReal(x1))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseCurveQTo", __FILE__, __LINE__);
			;
		float y1 = 0.0f;
		if (!parseReal(y1))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseCurveQTo", __FILE__, __LINE__);
			;
		float x = 0.0f;
		if (!parseReal(x))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseCurveQTo", __FILE__, __LINE__);
			;
		float y = 0.0f;
		if (!parseReal(y))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseCurveQTo", __FILE__, __LINE__);
			;
		curve.push_back(new Vector2(x1, y1) + offset);
		point = new Vector2(x, y) + offset;
		curve.push_back(point);
	}
	//-----------------------------------------------------------------------
	public static void SvgLoader.SvgLoaderPath.parseCurveTTo(bool rel, bool next)
	{
		if (next)
			index++;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: Vector2 offset = Vector2::ZERO;
		Vector2 offset = new Vector2(Vector2.ZERO);
		if (rel)
			offset = point;

		float x1 = point.x;
		float y1 = point.y;
		if (curve.size() > 2)
		{
			Vector2 mirror = curve[curve.size() - 2];
			Vector2 diff = mirror - point;
			x1 = -1.0f * diff.x + point.x;
			y1 = -1.0f * diff.y + point.y;
		}
		float x = 0.0f;
		if (!parseReal(x))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseCurveTTo", __FILE__, __LINE__);
			;
		float y = 0.0f;
		if (!parseReal(y))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseCurveTTo", __FILE__, __LINE__);
			;
		curve.push_back(new Vector2(x1, y1) + offset);
		point = new Vector2(x, y) + offset;
		curve.push_back(point);
	}
	//-----------------------------------------------------------------------
	public static void SvgLoader.SvgLoaderPath.parseCurveCTo(bool rel, bool next)
	{
		if (next)
			index++;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: Vector2 offset = Vector2::ZERO;
		Vector2 offset = new Vector2(Vector2.ZERO);
		if (rel)
			offset = point;

		float x1 = 0.0f;
		if (!parseReal(x1))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseCurveCTo", __FILE__, __LINE__);
			;
		float y1 = 0.0f;
		if (!parseReal(y1))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseCurveCTo", __FILE__, __LINE__);
			;
		float x2 = 0.0f;
		if (!parseReal(x2))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseCurveCTo", __FILE__, __LINE__);
			;
		float y2 = 0.0f;
		if (!parseReal(y2))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseCurveCTo", __FILE__, __LINE__);
			;
		float x = 0.0f;
		if (!parseReal(x))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseCurveCTo", __FILE__, __LINE__);
			;
		float y = 0.0f;
		if (!parseReal(y))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseCurveCTo", __FILE__, __LINE__);
			;
		curve.push_back(new Vector2(x1, y1) + offset);
		curve.push_back(new Vector2(x2, y2) + offset);
		point = new Vector2(x, y) + offset;
		curve.push_back(point);
	}
	//-----------------------------------------------------------------------
	public static void SvgLoader.SvgLoaderPath.parseMoveTo(bool rel, bool next)
	{
		if (next)
			index++;
		float x = 0f;
		float y = 0f;
		if (!parseReal(x))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseMoveTo", __FILE__, __LINE__);
			;
		if (!parseReal(y))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseMoveTo", __FILE__, __LINE__);
			;
		point = new Vector2(x, y);
		shape.addPoint(point);
	}
	//-----------------------------------------------------------------------
	public static void SvgLoader.SvgLoaderPath.parseLineTo(bool rel, bool next)
	{
		if (next)
			index++;
		float x = 0.0f;
		if (!parseReal(x))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseLineTo", __FILE__, __LINE__);
			;
		float y = 0.0f;
		if (!parseReal(y))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseLineTo", __FILE__, __LINE__);
			;
		if (rel)
			point = new Vector2(point.x + x, point.y + y);
		else
			point = new Vector2(x, y);
		shape.addPoint(point);
	}
	//-----------------------------------------------------------------------
	public static void SvgLoader.SvgLoaderPath.parseHLineTo(bool rel, bool next)
	{
		if (next)
			index++;
		float x = 0.0f;
		if (!parseReal(x))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseHLineTo", __FILE__, __LINE__);
			;
		if (rel)
			point.x += x;
		else
			point.x = x;
		shape.addPoint(point);
	}
	//-----------------------------------------------------------------------
	public static void SvgLoader.SvgLoaderPath.parseVLineTo(bool rel, bool next)
	{
		if (next)
			index++;
		float y = 0.0f;
		if (!parseReal(y))
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
			throw ExceptionFactory.create(Mogre.ExceptionCodeType<Mogre.Exception.ExceptionCodes.ERR_INVALIDPARAMS>(), "Expecting a float number", "parseVLineTo", __FILE__, __LINE__);
			;
		if (rel)
			point.y += y;
		else
			point.y = y;
		shape.addPoint(point);
	}
}
//
//-----------------------------------------------------------------------------
//This source file is part of ogre-procedural
//
//For the latest info, see http://www.ogreprocedural.org
//
//Copyright (c) 2012 Michael Broutin
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in
//all copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//THE SOFTWARE.
//-----------------------------------------------------------------------------
//
//
//-----------------------------------------------------------------------------
//This source file is part of ogre-procedural
//
//For the latest info, see http://code.google.com/p/ogre-procedural/
//
//Copyright (c) 2012 Michael Broutin
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in
//all copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//THE SOFTWARE.
//-----------------------------------------------------------------------------
//
#if ! PROCEDURAL_SVG_INCLUDED
#define PROCEDURAL_SVG_INCLUDED


#if ! DOXYGEN_SHOULD_SKIP_THIS
// Forward declarations
namespace rapidxml
{
//C++ TO C# CONVERTER TODO TASK: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Ch>
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class xml_node;
}
#endif

namespace Procedural
{
//-----------------------------------------------------------------------
//*
//Load shapes from an SVG file
//
//\b Example:
//\code
//    // -- Extrude SVG primitive shapes
//	Procedural::Path p;
//	p.addPoint(0, 0, 0);
//	p.addPoint(0, 100, 0);
//	int nr = 1;
//
//	Procedural::SvgLoader svg("test.svg", "Essential", 16);
//	for(Procedural::SvgLoader::iterator svgShape = svg.begin(); svgShape != svg.end(); svgShape++)
//	{
//		Procedural::Extruder().setShapeToExtrude(&svgShape->shape).setExtrusionPath(&p).setScale(1).realizeMesh(svgShape->id);
//		putMesh2(svgShape->id, Ogre::Vector3(svgShape->position.x, 10, svgShape->position.y));
//	}
//\endcode
// 
//C++ TO C# CONVERTER WARNING: The original type declaration contained unconverted modifiers:
//ORIGINAL LINE: class _ProceduralExport SvgLoader
public class SvgLoader <Ch>
{
	private uint mNumSeg;

	//* Internal class to parse path element 
	private class SvgLoaderPath
	{
		private int index = new int();
		private List<string> parts = new List<string>();
		private List<Vector2> curve = new List<Vector2>();
		private Vector2 point = new Vector2();
		private uint mNumSeg;

		public Shape shape = new Shape();
		public float px = 0f;
		public float py = 0f;

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//		SvgLoaderPath(List<string> p, uint ns);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//		void finishCurve(sbyte lc);

		public Shape getSvgShape()
		{
			shape.translate(px, py);
			return shape;
		}

		public bool isValid()
		{
			return shape.getPoints().size() > 2;
		}

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//		void parseMoveTo(bool rel, bool next);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//		void parseLineTo(bool rel, bool next);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//		void parseHLineTo(bool rel, bool next);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//		void parseVLineTo(bool rel, bool next);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//		void parseCurveCTo(bool rel, bool next);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//		void parseCurveSTo(bool rel, bool next);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//		void parseCurveQTo(bool rel, bool next);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//		void parseCurveTTo(bool rel, bool next);

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline Ogre::float CalculateVectorAngle(Ogre::float ux, Ogre::float uy, Ogre::float vx, Ogre::float vy) const
		private float CalculateVectorAngle(float ux, float uy, float vx, float vy)
		{
			double ta = Math.Atan2(uy, ux);
			double tb = Math.Atan2(vy, vx);

			if (tb >= ta)
				return (float)(tb - ta);

			return Math.TWO_PI - (float)(ta - tb);
		}

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//		void parseArcTo(bool rel, bool next);

		private bool parseReal(ref float var)
		{
			return parseReal(ref var, 0.0f);
		}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: inline bool parseReal(Ogre::Real* var, Ogre::float defaultReal = 0.0f)
		private bool parseReal(ref float var, float defaultReal)
		{
			if (var == null)
				return false;
			if (index >= parts.Count)
				return false;
			try
			{
				var = StringConverter.parseReal(ref parts[index], defaultReal);
				index++;
			}
			catch
			{
				return false;
			}
			return true;
		}
	}


//    *
//	Parses a SVG file
//	@param out MultiShape object where to store shapes from svg file
//	@param fileName Filename of svg file
//	@param groupName Resource group where svg file is listed
//	@param segmentsNumber Number of segments for curves
//	
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//	void parseSvgFile(ref MultiShape out, Ogre::String fileName, Ogre::String groupName, int segmentsNumber);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//	void parseChildNode(ref MultiShape out, rapidxml::xml_node<string> pChild);
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//	void parseRect(ref MultiShape out, rapidxml::xml_node<string> pRectNode);
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//	void parseCircle(ref MultiShape out, rapidxml::xml_node<string> pCircleNode);
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//	void parseEllipse(ref MultiShape out, rapidxml::xml_node<string> pEllipseNode);
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//	void parsePolygon(ref MultiShape out, rapidxml::xml_node<string> pPolygonNode);
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//	void parsePath(ref MultiShape out, rapidxml::xml_node<string> pPathNode);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//	Ogre::float getAttribReal(rapidxml::xml_node<string> pNode, Ogre::String attrib, Ogre::float defaultValue);
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//	Ogre::Vector2 getAttribTranslate(rapidxml::xml_node<string> pNode);
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//	List<string> split(string str, string delimiters, bool removeEmpty);
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//	string xtrim(string val, string achar, sbyte rchar);
}

}
#endif


// Copyright (C) 2006, 2009 Marcin Kalicinski
// Version 1.13
// Revision $DateTime: 2009/05/13 01:46:17 $
//! \file rapidxml.hpp This file contains rapidxml parser and DOM implementation

// If standard library is disabled, user must provide implementations of required functions and typedefs
#if !RAPIDXML_NO_STDLIB
#endif

// On MSVC, disable "conditional expression is constant" warning (level 4). 
// This warning is almost impossible to avoid with certain types of templated code
#if _MSC_VER
//C++ TO C# CONVERTER TODO TASK: There is no equivalent to most C++ 'pragma' directives in C#:
//    #pragma warning(push)
//C++ TO C# CONVERTER TODO TASK: There is no equivalent to most C++ 'pragma' directives in C#:
//    #pragma warning(disable:4127) // Conditional expression is constant
#endif

///////////////////////////////////////////////////////////////////////////
// RAPIDXML_PARSE_ERROR

#if RAPIDXML_NO_EXCEPTIONS

//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define RAPIDXML_PARSE_ERROR(what, where) { parse_error_handler(what, where); assert(0); }
#define RAPIDXML_PARSE_ERROR

namespace rapidxml
{
}

#else


//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define RAPIDXML_PARSE_ERROR(what, where) throw parse_error(what, where)
#define RAPIDXML_PARSE_ERROR

namespace rapidxml
{

	//! Parse error exception. 
	//! This exception is thrown by the parser when an error occurs. 
	//! Use what() function to get human-readable error message. 
	//! Use where() function to get a pointer to position within source text where error was detected.
	//! <br><br>
	//! If throwing exceptions by the parser is undesirable, 
	//! it can be disabled by defining RAPIDXML_NO_EXCEPTIONS macro before rapidxml.hpp is included.
	//! This will cause the parser to call rapidxml::parse_error_handler() function instead of throwing an exception.
	//! This function must be defined by the user.
	//! <br><br>
	//! This class derives from <code>std::exception</code> class.
	public class parse_error: std.exception
	{


		//! Constructs parse error
		public parse_error(string what, IntPtr @where)
		{
			m_what = what;
			m_where = @where;
		}

		//! Gets human readable description of error.
		//! \return Pointer to null terminated description of the error.
//C++ TO C# CONVERTER WARNING: Throw clauses are not available in C#:
//ORIGINAL LINE: virtual string what() const throw()
		public virtual string what() const
		{
			return m_what;
		}

		//! Gets pointer to character data where error happened.
		//! Ch should be the same as char type of xml_document that produced the error.
		//! \return Pointer to location within the parsed string where error occured.
//C++ TO C# CONVERTER TODO TASK: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Ch>
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: Ch *where() const
		public Ch where<Ch>()
		{
//C++ TO C# CONVERTER TODO TASK: There is no equivalent to 'reinterpret_cast' in C#:
			return reinterpret_cast<Ch *>(m_where);
		}


		private string m_what;
		private IntPtr m_where;

	}
}

#endif

///////////////////////////////////////////////////////////////////////////
// Pool sizes

#if ! RAPIDXML_STATIC_POOL_SIZE
	// Size of static memory block of memory_pool.
	// Define RAPIDXML_STATIC_POOL_SIZE before including rapidxml.hpp if you want to override the default value.
	// No dynamic memory allocations are performed by memory_pool until static memory is exhausted.
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define RAPIDXML_STATIC_POOL_SIZE (64 * 1024)
	#define RAPIDXML_STATIC_POOL_SIZE
#endif

#if ! RAPIDXML_DYNAMIC_POOL_SIZE
	// Size of dynamic memory block of memory_pool.
	// Define RAPIDXML_DYNAMIC_POOL_SIZE before including rapidxml.hpp if you want to override the default value.
	// After the static block is exhausted, dynamic blocks with approximately this size are allocated by memory_pool.
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define RAPIDXML_DYNAMIC_POOL_SIZE (64 * 1024)
	#define RAPIDXML_DYNAMIC_POOL_SIZE
#endif

#if ! RAPIDXML_ALIGNMENT
	// Memory allocation alignment.
	// Define RAPIDXML_ALIGNMENT before including rapidxml.hpp if you want to override the default value, which is the size of pointer.
	// All memory allocations for nodes, attributes and strings will be aligned to this value.
	// This must be a power of 2 and at least 1, otherwise memory_pool will not work.
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define RAPIDXML_ALIGNMENT sizeof(void *)
	#define RAPIDXML_ALIGNMENT
#endif

namespace rapidxml
{
//C++ TO C# CONVERTER TODO TASK: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Ch>
	// Forward declarations
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//	class xml_node;
//C++ TO C# CONVERTER TODO TASK: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Ch>
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//	class xml_attribute;
//C++ TO C# CONVERTER TODO TASK: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Ch>
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//	class xml_document;

	//! Enumeration listing all node types produced by the parser.
	//! Use xml_node::type() function to query node type.
	public enum node_type: int
	{
		node_document, //!< A document node. Name and value are empty.
		node_element, //!< An element node. Name contains element name. Value contains text of first data node.
		node_data, //!< A data node. Name is empty. Value contains data text.
		node_cdata, //!< A CDATA node. Name is empty. Value contains data text.
		node_comment, //!< A comment node. Name is empty. Value contains comment text.
		node_declaration, //!< A declaration node. Name and value are empty. Declaration parameters (version, encoding and standalone) are in node attributes.
		node_doctype, //!< A DOCTYPE node. Name is empty. Value contains DOCTYPE text.
		node_pi //!< A PI node. Name contains target. Value contains instructions.
	}

	///////////////////////////////////////////////////////////////////////
	// Internals

	//! \cond internal
	namespace internal
	{
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Dummy>

		// Struct that contains lookup tables for the parser
		// It must be a template to allow correct linking (because it has static data members, which are defined in a header file).
		public class lookup_tables <int Dummy>
		{
			public readonly byte[] lookup_whitespace = new byte[256]; // Whitespace table
			public readonly byte[] lookup_node_name = new byte[256]; // Node name table
			public readonly byte[] lookup_text = new byte[256]; // Text table
			public readonly byte[] lookup_text_pure_no_ws = new byte[256]; // Text table
			public readonly byte[] lookup_text_pure_with_ws = new byte[256]; // Text table
			public readonly byte[] lookup_attribute_name = new byte[256]; // Attribute name table
			public readonly byte[] lookup_attribute_data_1 = new byte[256]; // Attribute data table with single quote
			public readonly byte[] lookup_attribute_data_1_pure = new byte[256]; // Attribute data table with single quote
			public readonly byte[] lookup_attribute_data_2 = new byte[256]; // Attribute data table with double quotes
			public readonly byte[] lookup_attribute_data_2_pure = new byte[256]; // Attribute data table with double quotes
			public readonly byte[] lookup_digits = new byte[256]; // Digits
			public readonly byte[] lookup_upcase = new byte[256]; // To uppercase conversion table for ASCII characters
		}
//C++ TO C# CONVERTER TODO TASK: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Ch>
	}
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers containing defaults cannot be converted to C#:
//ORIGINAL LINE: template<class Ch = sbyte>
	//! \endcond

	///////////////////////////////////////////////////////////////////////
	// Memory pool

	//! This class is used by the parser to create new nodes and attributes, without overheads of dynamic memory allocation.
	//! In most cases, you will not need to use this class directly. 
	//! However, if you need to create nodes manually or modify names/values of nodes, 
	//! you are encouraged to use memory_pool of relevant xml_document to allocate the memory. 
	//! Not only is this faster than allocating them by using <code>new</code> operator, 
	//! but also their lifetime will be tied to the lifetime of document, 
	//! possibly simplyfing memory management. 
	//! <br><br>
	//! Call allocate_node() or allocate_attribute() functions to obtain new nodes or attributes from the pool. 
	//! You can also call allocate_string() function to allocate strings.
	//! Such strings can then be used as names or values of nodes without worrying about their lifetime.
	//! Note that there is no <code>free()</code> function -- all allocations are freed at once when clear() function is called, 
	//! or when the pool is destroyed.
	//! <br><br>
	//! It is also possible to create a standalone memory_pool, and use it 
	//! to allocate nodes, whose lifetime will not be tied to any document.
	//! <br><br>
	//! Pool maintains <code>RAPIDXML_STATIC_POOL_SIZE</code> bytes of statically allocated memory. 
	//! Until static memory is exhausted, no dynamic memory allocations are done.
	//! When static memory is exhausted, pool allocates additional blocks of memory of size <code>RAPIDXML_DYNAMIC_POOL_SIZE</code> each,
	//! by using global <code>new[]</code> and <code>delete[]</code> operators. 
	//! This behaviour can be changed by setting custom allocation routines. 
	//! Use set_allocator() function to set them.
	//! <br><br>
	//! Allocations for nodes, attributes and strings are aligned at <code>RAPIDXML_ALIGNMENT</code> bytes.
	//! This value defaults to the size of pointer on target architecture.
	//! <br><br>
	//! To obtain absolutely top performance from the parser,
	//! it is important that all nodes are allocated from a single, contiguous block of memory.
	//! Otherwise, cache misses when jumping between two (or more) disjoint blocks of memory can slow down parsing quite considerably.
	//! If required, you can tweak <code>RAPIDXML_STATIC_POOL_SIZE</code>, <code>RAPIDXML_DYNAMIC_POOL_SIZE</code> and <code>RAPIDXML_ALIGNMENT</code> 
	//! to obtain best wasted memory to performance compromise.
	//! To do it, define their values before rapidxml.hpp file is included.
	//! \param Ch Character type of created nodes. 
	public class memory_pool <Ch = sbyte>
	{


		//! \cond internal
		typedef IntPtr (alloc_func)(std.int); // Type of user-defined function used to allocate memory
		typedef void (free_func)(IntPtr); // Type of user-defined function used to free memory
		//! \endcond

		//! Constructs empty pool with default allocator functions.
		public memory_pool()
		{
			m_alloc_func = 0;
			m_free_func = 0;
			init();
		}

		//! Destroys pool and frees all the memory. 
		//! This causes memory occupied by nodes allocated by the pool to be freed.
		//! Nodes allocated from the pool are no longer valid.
		public void Dispose()
		{
			clear();
		}

		//! Allocates a new node from the pool, and optionally assigns name and value to it. 
		//! If the allocation request cannot be accomodated, this function will throw <code>std::bad_alloc</code>.
		//! If exceptions are disabled by defining RAPIDXML_NO_EXCEPTIONS, this function
		//! will call rapidxml::parse_error_handler() function.
		//! \param type Type of node to create.
		//! \param name Name to assign to the node, or 0 to assign no name.
		//! \param value Value to assign to the node, or 0 to assign no value.
		//! \param name_size Size of name to assign, or 0 to automatically calculate size from name string.
		//! \param value_size Size of value to assign, or 0 to automatically calculate size from value string.
		//! \return Pointer to allocated node. This pointer will never be NULL.
		public xml_node<Ch> *allocate_node(node_type type, Ch name, Ch value, std.int name_size)
		{
			return allocate_node(type, name, value, name_size, 0);
		}
		public xml_node<Ch> *allocate_node(node_type type, Ch name, Ch value)
		{
			return allocate_node(type, name, value, 0, 0);
		}
		public xml_node<Ch> *allocate_node(node_type type, Ch name)
		{
			return allocate_node(type, name, 0, 0, 0);
		}
		public xml_node<Ch> *allocate_node(node_type type)
		{
			return allocate_node(type, 0, 0, 0, 0);
		}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: xml_node<Ch> *allocate_node(node_type type, const Ch *name = 0, const Ch *value = 0, std::int name_size = 0, std::int value_size = 0)
		public xml_node<Ch> *allocate_node(node_type type, Ch name, Ch @value, std.int name_size, std.int value_size)
		{
			IntPtr memory = allocate_aligned(sizeof(xml_node<Ch>));
			xml_node<Ch> node = new(memory) xml_node<Ch>(type);
			if (name != null)
			{
				if (name_size > 0)
					node.name(name, name_size);
				else
					node.name(name);
			}
			if (@value != null)
			{
				if (value_size > 0)
					node.@value(@value, value_size);
				else
					node.@value(@value);
			}
			return node;
		}

		//! Allocates a new attribute from the pool, and optionally assigns name and value to it.
		//! If the allocation request cannot be accomodated, this function will throw <code>std::bad_alloc</code>.
		//! If exceptions are disabled by defining RAPIDXML_NO_EXCEPTIONS, this function
		//! will call rapidxml::parse_error_handler() function.
		//! \param name Name to assign to the attribute, or 0 to assign no name.
		//! \param value Value to assign to the attribute, or 0 to assign no value.
		//! \param name_size Size of name to assign, or 0 to automatically calculate size from name string.
		//! \param value_size Size of value to assign, or 0 to automatically calculate size from value string.
		//! \return Pointer to allocated attribute. This pointer will never be NULL.
		public xml_attribute<Ch> *allocate_attribute(Ch name, Ch value, std.int name_size)
		{
			return allocate_attribute(name, value, name_size, 0);
		}
		public xml_attribute<Ch> *allocate_attribute(Ch name, Ch value)
		{
			return allocate_attribute(name, value, 0, 0);
		}
		public xml_attribute<Ch> *allocate_attribute(Ch name)
		{
			return allocate_attribute(name, 0, 0, 0);
		}
		public xml_attribute<Ch> *allocate_attribute()
		{
			return allocate_attribute(0, 0, 0, 0);
		}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: xml_attribute<Ch> *allocate_attribute(const Ch *name = 0, const Ch *value = 0, std::int name_size = 0, std::int value_size = 0)
		public xml_attribute<Ch> *allocate_attribute(Ch name, Ch @value, std.int name_size, std.int value_size)
		{
			IntPtr memory = allocate_aligned(sizeof(xml_attribute<Ch>));
			xml_attribute<Ch> attribute = new(memory) xml_attribute<Ch>;
			if (name != null)
			{
				if (name_size > 0)
					attribute.name(name, name_size);
				else
					attribute.name(name);
			}
			if (@value != null)
			{
				if (value_size > 0)
					attribute.@value(@value, value_size);
				else
					attribute.@value(@value);
			}
			return attribute;
		}

		//! Allocates a char array of given size from the pool, and optionally copies a given string to it.
		//! If the allocation request cannot be accomodated, this function will throw <code>std::bad_alloc</code>.
		//! If exceptions are disabled by defining RAPIDXML_NO_EXCEPTIONS, this function
		//! will call rapidxml::parse_error_handler() function.
		//! \param source String to initialize the allocated memory with, or 0 to not initialize it.
		//! \param size Number of characters to allocate, or zero to calculate it automatically from source string length; if size is 0, source string must be specified and null terminated.
		//! \return Pointer to allocated char array. This pointer will never be NULL.
		public Ch allocate_string(Ch[] source)
		{
			return allocate_string(source, 0);
		}
		public Ch allocate_string()
		{
			return allocate_string(0, 0);
		}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: Ch *allocate_string(const Ch *source = 0, std::int size = 0)
		public Ch allocate_string(Ch[] source, std.int size)
		{
			Debug.Assert(source != null || size != null); // Either source or size (or both) must be specified
			if (size == 0)
				size = GlobalMembersProceduralSVG.measure(source) + 1;
			Ch[] result = (Ch)(allocate_aligned(size * sizeof(Ch)));
			if (source != null)
				for (std.int i = 0; i < size; ++i)
					result[i] = source[i];
			return result;
		}

		//! Clones an xml_node and its hierarchy of child nodes and attributes.
		//! Nodes and attributes are allocated from this memory pool.
		//! Names and values are not cloned, they are shared between the clone and the source.
		//! Result node can be optionally specified as a second parameter, 
		//! in which case its contents will be replaced with cloned source node.
		//! This is useful when you want to clone entire document.
		//! \param source Node to clone.
		//! \param result Node to put results in, or 0 to automatically allocate result node
		//! \return Pointer to cloned node. This pointer will never be NULL.
		public xml_node<Ch> *clone_node(xml_node<Ch> source)
		{
			return clone_node(source, 0);
		}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: xml_node<Ch> *clone_node(const xml_node<Ch> *source, xml_node<Ch> *result = 0)
		public xml_node<Ch> *clone_node(xml_node<Ch> source, xml_node<Ch> result)
		{
			// Prepare result node
			if (result != null)
			{
				result.remove_all_attributes();
				result.remove_all_nodes();
				result.type(source.type());
			}
			else
				result = allocate_node(source.type());

			// Clone name and value
			result.name(source.name(), source.name_size());
			result.@value(source.@value(), source.value_size());

			// Clone child nodes and attributes
			for (xml_node<Ch> child = source.first_node(); child; child = child.next_sibling())
				result.append_node(clone_node(child));
			for (xml_attribute<Ch> attr = source.first_attribute(); attr; attr = attr.next_attribute())
				result.append_attribute(allocate_attribute(attr.name(), attr.@value(), attr.name_size(), attr.value_size()));

			return result;
		}

		//! Clears the pool. 
		//! This causes memory occupied by nodes allocated by the pool to be freed.
		//! Any nodes or strings allocated from the pool will no longer be valid.
		public void clear()
		{
			while (m_begin != m_static_memory)
			{
//C++ TO C# CONVERTER TODO TASK: There is no equivalent to 'reinterpret_cast' in C#:
				string previous_begin = reinterpret_cast<header *>(align(ref m_begin)).previous_begin;
				if (m_free_func != null)
					m_free_func(m_begin);
				else
					m_begin = null;
				m_begin = previous_begin;
			}
			init();
		}

		//! Sets or resets the user-defined memory allocation functions for the pool.
		//! This can only be called when no memory is allocated from the pool yet, otherwise results are undefined.
		//! Allocation function must not return invalid pointer on failure. It should either throw,
		//! stop the program, or use <code>longjmp()</code> function to pass control to other place of program. 
		//! If it returns invalid pointer, results are undefined.
		//! <br><br>
		//! User defined allocation functions must have the following forms:
		//! <br><code>
		//! <br>void *allocate(std::int size);
		//! <br>void free(void *pointer);
		//! </code><br>
		//! \param af Allocation function, or 0 to restore default function
		//! \param ff Free function, or 0 to restore default function
		public void set_allocator(ref alloc_func af, ref free_func ff)
		{
			Debug.Assert(m_begin == m_static_memory && m_ptr == align(ref m_begin)); // Verify that no memory is allocated yet
			m_alloc_func = af;
			m_free_func = ff;
		}


		private class header
		{
			public string previous_begin;
		}

		private void init()
		{
			m_begin = m_static_memory;
			m_ptr = align(ref m_begin);
			m_end = m_static_memory + sizeof(m_static_memory);
		}

		private string align(ref string ptr)
		{
			std.int alignment = ((sizeof(IntPtr) - (std.int(ptr) & (sizeof(IntPtr) - 1))) & (sizeof(IntPtr) - 1));
			return ptr + alignment;
		}

		private string allocate_raw(std.int size)
		{
			// Allocate
			IntPtr memory;
			if (m_alloc_func != null) // Allocate memory using either user-specified allocation function or global operator new[]
			{
				memory = m_alloc_func(size);
				Debug.Assert(memory); // Allocator is not allowed to return 0, on failure it must either throw, stop the program or use longjmp
			}
			else
			{
				memory = new sbyte[size];
#if RAPIDXML_NO_EXCEPTIONS
				if (!memory) // If exceptions are disabled, verify memory allocation, because new will not be able to throw bad_alloc
					RAPIDXML_PARSE_ERROR("out of memory", 0);
#endif
			}
			return (sbyte)(memory);
		}

		private IntPtr allocate_aligned(std.int size)
		{
			// Calculate aligned pointer
			sbyte result = align(ref m_ptr);

			// If not enough memory left in current pool, allocate a new pool
			if (result + size > m_end)
			{
				// Calculate required pool size (may be bigger than RAPIDXML_DYNAMIC_POOL_SIZE)
				std.int pool_size = 64 * 1024;
				if (pool_size < size)
					pool_size = size;

				// Allocate
				std.int alloc_size = sizeof(header) + (2 * sizeof(IntPtr) - 2) + pool_size; // 2 alignments required in worst case: one for header, one for actual allocation
				sbyte raw_memory = allocate_raw(alloc_size);

				// Setup new pool in allocated memory
				sbyte pool = align(ref raw_memory);
//C++ TO C# CONVERTER TODO TASK: There is no equivalent to 'reinterpret_cast' in C#:
				header new_header = reinterpret_cast<header *>(pool);
				new_header.previous_begin = m_begin;
				m_begin = raw_memory;
				m_ptr = pool + sizeof(header);
				m_end = raw_memory + alloc_size;

				// Calculate aligned pointer again using new pool
				result = align(ref m_ptr);
			}

			// Update pool and return aligned pointer
			m_ptr = result + size;
			return result;
		}

		private string m_begin; // Start of raw memory making up current pool
		private string m_ptr; // First free byte in current pool
		private string m_end; // One past last available byte in current pool
		private string m_static_memory = new string(new char[64 * 1024]); // Static raw memory
		private alloc_func m_alloc_func; // Allocator function, or 0 if default is to be used
		private free_func m_free_func; // Free function, or 0 if default is to be used
	}
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers containing defaults cannot be converted to C#:
//ORIGINAL LINE: template<class Ch = sbyte>

	///////////////////////////////////////////////////////////////////////////
	// XML base

	//! Base class for xml_node and xml_attribute implementing common functions: 
	//! name(), name_size(), value(), value_size() and parent().
	//! \param Ch Character type to use
	public class xml_base <Ch = sbyte>
	{


		///////////////////////////////////////////////////////////////////////////
		// Construction & destruction

		// Construct a base with empty name, value and parent
		public xml_base()
		{
			m_name = 0;
			m_value = 0;
			m_parent = 0;
		}

		///////////////////////////////////////////////////////////////////////////
		// Node data access

		//! Gets name of the node. 
		//! Interpretation of name depends on type of node.
		//! Note that name will not be zero-terminated if rapidxml::parse_no_string_terminators option was selected during parse.
		//! <br><br>
		//! Use name_size() function to determine length of the name.
		//! \return Name of node, or empty string if node has no name.
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: Ch *name() const
		public Ch name()
		{
			return m_name != null ? m_name : nullstr();
		}

		//! Gets size of node name, not including terminator character.
		//! This function works correctly irrespective of whether name is or is not zero terminated.
		//! \return Size of node name, in characters.
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: std::int name_size() const
		public std.int name_size()
		{
			return m_name != null ? m_name_size : 0;
		}

		//! Gets value of node. 
		//! Interpretation of value depends on type of node.
		//! Note that value will not be zero-terminated if rapidxml::parse_no_string_terminators option was selected during parse.
		//! <br><br>
		//! Use value_size() function to determine length of the value.
		//! \return Value of node, or empty string if node has no value.
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: Ch *value() const
		public Ch @value()
		{
			return m_value != null ? m_value : nullstr();
		}

		//! Gets size of node value, not including terminator character.
		//! This function works correctly irrespective of whether value is or is not zero terminated.
		//! \return Size of node value, in characters.
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: std::int value_size() const
		public std.int value_size()
		{
			return m_value != null ? m_value_size : 0;
		}

		///////////////////////////////////////////////////////////////////////////
		// Node modification

		//! Sets name of node to a non zero-terminated string.
		//! See \ref ownership_of_strings.
		//! <br><br>
		//! Note that node does not own its name or value, it only stores a pointer to it. 
		//! It will not delete or otherwise free the pointer on destruction.
		//! It is reponsibility of the user to properly manage lifetime of the string.
		//! The easiest way to achieve it is to use memory_pool of the document to allocate the string -
		//! on destruction of the document the string will be automatically freed.
		//! <br><br>
		//! Size of name must be specified separately, because name does not have to be zero terminated.
		//! Use name(const Ch *) function to have the length automatically calculated (string must be zero terminated).
		//! \param name Name of node to set. Does not have to be zero terminated.
		//! \param size Size of name, in characters. This does not include zero terminator, if one is present.
		public void name(Ch name, std.int size)
		{
//C++ TO C# CONVERTER TODO TASK: There is no equivalent to 'const_cast' in C#:
			m_name = const_cast<Ch *>(name);
			m_name_size = size;
		}

		//! Sets name of node to a zero-terminated string.
		//! See also \ref ownership_of_strings and xml_node::name(const Ch *, std::int).
		//! \param name Name of node to set. Must be zero terminated.
		public void name(Ch name)
		{
			this.name(name, GlobalMembersProceduralSVG.measure(name));
		}

		//! Sets value of node to a non zero-terminated string.
		//! See \ref ownership_of_strings.
		//! <br><br>
		//! Note that node does not own its name or value, it only stores a pointer to it. 
		//! It will not delete or otherwise free the pointer on destruction.
		//! It is reponsibility of the user to properly manage lifetime of the string.
		//! The easiest way to achieve it is to use memory_pool of the document to allocate the string -
		//! on destruction of the document the string will be automatically freed.
		//! <br><br>
		//! Size of value must be specified separately, because it does not have to be zero terminated.
		//! Use value(const Ch *) function to have the length automatically calculated (string must be zero terminated).
		//! <br><br>
		//! If an element has a child node of type node_data, it will take precedence over element value when printing.
		//! If you want to manipulate data of elements using values, use parser flag rapidxml::parse_no_data_nodes to prevent creation of data nodes by the parser.
		//! \param value value of node to set. Does not have to be zero terminated.
		//! \param size Size of value, in characters. This does not include zero terminator, if one is present.
		public void @value(Ch @value, std.int size)
		{
//C++ TO C# CONVERTER TODO TASK: There is no equivalent to 'const_cast' in C#:
			m_value = const_cast<Ch *>(@value);
			m_value_size = size;
		}

		//! Sets value of node to a zero-terminated string.
		//! See also \ref ownership_of_strings and xml_node::value(const Ch *, std::int).
		//! \param value Vame of node to set. Must be zero terminated.
		public void @value(Ch @value)
		{
			this.@value(@value, GlobalMembersProceduralSVG.measure(@value));
		}

		///////////////////////////////////////////////////////////////////////////
		// Related nodes access

		//! Gets node parent.
		//! \return Pointer to parent node, or 0 if there is no parent.
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: xml_node<Ch> *parent() const
		public xml_node<Ch> *parent()
		{
			return m_parent;
		}


		// Return empty string
//C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):
		private static Ch zero = new Ch('\0');
		protected static Ch nullstr()
		{
//C++ TO C# CONVERTER NOTE: This static local variable declaration (not allowed in C#) has been moved just prior to the method:
//			static Ch zero = Ch('\0');
			return zero;
		}

		protected Ch m_name; // Name of node, or 0 if no name
		protected Ch m_value; // Value of node, or 0 if no value
		protected std.int m_name_size = new std.int(); // Length of node name, or undefined of no name
		protected std.int m_value_size = new std.int(); // Length of node value, or undefined if no value
		protected xml_node<Ch> m_parent; // Pointer to parent node, or 0 if none

	}
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers containing defaults cannot be converted to C#:
//ORIGINAL LINE: template<class Ch = sbyte>

	//! Class representing attribute node of XML document. 
	//! Each attribute has name and value strings, which are available through name() and value() functions (inherited from xml_base).
	//! Note that after parse, both name and value of attribute will point to interior of source text used for parsing. 
	//! Thus, this text must persist in memory for the lifetime of attribute.
	//! \param Ch Character type to use.
	public class xml_attribute<Ch = sbyte>: xml_base<Ch>
	{

//C++ TO C# CONVERTER TODO TASK: C# has no concept of a 'friend' class:
//		friend class xml_node<Ch>;


		///////////////////////////////////////////////////////////////////////////
		// Construction & destruction

		//! Constructs an empty attribute with the specified type. 
		//! Consider using memory_pool of appropriate xml_document if allocating attributes manually.
		public xml_attribute()
		{
		}

		///////////////////////////////////////////////////////////////////////////
		// Related nodes access

		//! Gets document of which attribute is a child.
		//! \return Pointer to document that contains this attribute, or 0 if there is no parent document.
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: xml_document<Ch> *document() const
		public xml_document<Ch> *document()
		{
			if (xml_node<Ch> *node = this.parent())
			{
				while (node.parent())
					node = node.parent();
				return node.type() == (int)node_type.node_document ? (xml_document<Ch>)(node) : 0;
			}
			else
				return 0;
		}

		//! Gets previous attribute, optionally matching attribute name. 
		//! \param name Name of attribute to find, or 0 to return previous attribute regardless of its name; this string doesn't have to be zero-terminated if name_size is non-zero
		//! \param name_size Size of name, in characters, or 0 to have size calculated automatically from string
		//! \param case_sensitive Should name comparison be case-sensitive; non case-sensitive comparison works properly only for ASCII characters
		//! \return Pointer to found attribute, or 0 if not found.
		public xml_attribute<Ch> *previous_attribute(Ch name, std.int name_size)
		{
			return previous_attribute(name, name_size, true);
		}
		public xml_attribute<Ch> *previous_attribute(Ch name)
		{
			return previous_attribute(name, 0, true);
		}
		public xml_attribute<Ch> *previous_attribute()
		{
			return previous_attribute(0, 0, true);
		}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: xml_attribute<Ch> *previous_attribute(const Ch *name = 0, std::int name_size = 0, bool case_sensitive = true) const
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
		public xml_attribute<Ch> *previous_attribute(Ch name, std.int name_size, bool case_sensitive)
		{
			if (name != null)
			{
				if (name_size == 0)
					name_size = GlobalMembersProceduralSVG.measure(name);
				for (xml_attribute<Ch> attribute = m_prev_attribute; attribute; attribute = attribute.m_prev_attribute)
					if (GlobalMembersProceduralSVG.compare(attribute.name(), attribute.name_size(), name, name_size, case_sensitive) != 0)
						return attribute;
				return 0;
			}
			else
				return this.m_parent ? m_prev_attribute : 0;
		}

		//! Gets next attribute, optionally matching attribute name. 
		//! \param name Name of attribute to find, or 0 to return next attribute regardless of its name; this string doesn't have to be zero-terminated if name_size is non-zero
		//! \param name_size Size of name, in characters, or 0 to have size calculated automatically from string
		//! \param case_sensitive Should name comparison be case-sensitive; non case-sensitive comparison works properly only for ASCII characters
		//! \return Pointer to found attribute, or 0 if not found.
		public xml_attribute<Ch> *next_attribute(Ch name, std.int name_size)
		{
			return next_attribute(name, name_size, true);
		}
		public xml_attribute<Ch> *next_attribute(Ch name)
		{
			return next_attribute(name, 0, true);
		}
		public xml_attribute<Ch> *next_attribute()
		{
			return next_attribute(0, 0, true);
		}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: xml_attribute<Ch> *next_attribute(const Ch *name = 0, std::int name_size = 0, bool case_sensitive = true) const
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
		public xml_attribute<Ch> *next_attribute(Ch name, std.int name_size, bool case_sensitive)
		{
			if (name != null)
			{
				if (name_size == 0)
					name_size = GlobalMembersProceduralSVG.measure(name);
				for (xml_attribute<Ch> attribute = m_next_attribute; attribute; attribute = attribute.m_next_attribute)
					if (GlobalMembersProceduralSVG.compare(attribute.name(), attribute.name_size(), name, name_size, case_sensitive) != 0)
						return attribute;
				return 0;
			}
			else
				return this.m_parent ? m_next_attribute : 0;
		}


		private xml_attribute<Ch> m_prev_attribute; // Pointer to previous sibling of attribute, or 0 if none; only valid if parent is non-zero
		private xml_attribute<Ch> m_next_attribute; // Pointer to next sibling of attribute, or 0 if none; only valid if parent is non-zero

	}
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers containing defaults cannot be converted to C#:
//ORIGINAL LINE: template<class Ch = sbyte>

	///////////////////////////////////////////////////////////////////////////
	// XML node

	//! Class representing a node of XML document. 
	//! Each node may have associated name and value strings, which are available through name() and value() functions. 
	//! Interpretation of name and value depends on type of the node.
	//! Type of node can be determined by using type() function.
	//! <br><br>
	//! Note that after parse, both name and value of node, if any, will point interior of source text used for parsing. 
	//! Thus, this text must persist in the memory for the lifetime of node.
	//! \param Ch Character type to use.
	public class xml_node<Ch = sbyte>: xml_base<Ch>
	{


		///////////////////////////////////////////////////////////////////////////
		// Construction & destruction

		//! Constructs an empty node with the specified type. 
		//! Consider using memory_pool of appropriate document to allocate nodes manually.
		//! \param type Type of node to construct.
		public xml_node(node_type type)
		{
			m_type = type;
			m_first_node = 0;
			m_first_attribute = 0;
		}

		///////////////////////////////////////////////////////////////////////////
		// Node data access

		//! Gets type of node.
		//! \return Type of node.
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: node_type type() const
		public node_type type()
		{
			return m_type;
		}

		///////////////////////////////////////////////////////////////////////////
		// Related nodes access

		//! Gets document of which node is a child.
		//! \return Pointer to document that contains this node, or 0 if there is no parent document.
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: xml_document<Ch> *document() const
		public xml_document<Ch> *document()
		{
//C++ TO C# CONVERTER TODO TASK: There is no equivalent to 'const_cast' in C#:
			xml_node<Ch> node = const_cast<xml_node<Ch> *>(this);
			while (node.parent())
				node = node.parent();
			return node.type() == (int)node_type.node_document ? (xml_document<Ch>)(node) : 0;
		}

		//! Gets first child node, optionally matching node name.
		//! \param name Name of child to find, or 0 to return first child regardless of its name; this string doesn't have to be zero-terminated if name_size is non-zero
		//! \param name_size Size of name, in characters, or 0 to have size calculated automatically from string
		//! \param case_sensitive Should name comparison be case-sensitive; non case-sensitive comparison works properly only for ASCII characters
		//! \return Pointer to found child, or 0 if not found.
		public xml_node<Ch> *first_node(Ch name, std.int name_size)
		{
			return first_node(name, name_size, true);
		}
		public xml_node<Ch> *first_node(Ch name)
		{
			return first_node(name, 0, true);
		}
		public xml_node<Ch> *first_node()
		{
			return first_node(0, 0, true);
		}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: xml_node<Ch> *first_node(const Ch *name = 0, std::int name_size = 0, bool case_sensitive = true) const
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
		public xml_node<Ch> *first_node(Ch name, std.int name_size, bool case_sensitive)
		{
			if (name != null)
			{
				if (name_size == 0)
					name_size = GlobalMembersProceduralSVG.measure(name);
				for (xml_node<Ch> child = m_first_node; child; child = child.next_sibling())
					if (GlobalMembersProceduralSVG.compare(child.name(), child.name_size(), name, name_size, case_sensitive) != 0)
						return child;
				return 0;
			}
			else
				return m_first_node;
		}

		//! Gets last child node, optionally matching node name. 
		//! Behaviour is undefined if node has no children.
		//! Use first_node() to test if node has children.
		//! \param name Name of child to find, or 0 to return last child regardless of its name; this string doesn't have to be zero-terminated if name_size is non-zero
		//! \param name_size Size of name, in characters, or 0 to have size calculated automatically from string
		//! \param case_sensitive Should name comparison be case-sensitive; non case-sensitive comparison works properly only for ASCII characters
		//! \return Pointer to found child, or 0 if not found.
		public xml_node<Ch> *last_node(Ch name, std.int name_size)
		{
			return last_node(name, name_size, true);
		}
		public xml_node<Ch> *last_node(Ch name)
		{
			return last_node(name, 0, true);
		}
		public xml_node<Ch> *last_node()
		{
			return last_node(0, 0, true);
		}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: xml_node<Ch> *last_node(const Ch *name = 0, std::int name_size = 0, bool case_sensitive = true) const
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
		public xml_node<Ch> *last_node(Ch name, std.int name_size, bool case_sensitive)
		{
			Debug.Assert(m_first_node); // Cannot query for last child if node has no children
			if (name != null)
			{
				if (name_size == 0)
					name_size = GlobalMembersProceduralSVG.measure(name);
				for (xml_node<Ch> child = m_last_node; child; child = child.previous_sibling())
					if (GlobalMembersProceduralSVG.compare(child.name(), child.name_size(), name, name_size, case_sensitive) != 0)
						return child;
				return 0;
			}
			else
				return m_last_node;
		}

		//! Gets previous sibling node, optionally matching node name. 
		//! Behaviour is undefined if node has no parent.
		//! Use parent() to test if node has a parent.
		//! \param name Name of sibling to find, or 0 to return previous sibling regardless of its name; this string doesn't have to be zero-terminated if name_size is non-zero
		//! \param name_size Size of name, in characters, or 0 to have size calculated automatically from string
		//! \param case_sensitive Should name comparison be case-sensitive; non case-sensitive comparison works properly only for ASCII characters
		//! \return Pointer to found sibling, or 0 if not found.
		public xml_node<Ch> *previous_sibling(Ch name, std.int name_size)
		{
			return previous_sibling(name, name_size, true);
		}
		public xml_node<Ch> *previous_sibling(Ch name)
		{
			return previous_sibling(name, 0, true);
		}
		public xml_node<Ch> *previous_sibling()
		{
			return previous_sibling(0, 0, true);
		}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: xml_node<Ch> *previous_sibling(const Ch *name = 0, std::int name_size = 0, bool case_sensitive = true) const
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
		public xml_node<Ch> *previous_sibling(Ch name, std.int name_size, bool case_sensitive)
		{
			Debug.Assert(this.m_parent); // Cannot query for siblings if node has no parent
			if (name != null)
			{
				if (name_size == 0)
					name_size = GlobalMembersProceduralSVG.measure(name);
				for (xml_node<Ch> sibling = m_prev_sibling; sibling; sibling = sibling.m_prev_sibling)
					if (GlobalMembersProceduralSVG.compare(sibling.name(), sibling.name_size(), name, name_size, case_sensitive) != 0)
						return sibling;
				return 0;
			}
			else
				return m_prev_sibling;
		}

		//! Gets next sibling node, optionally matching node name. 
		//! Behaviour is undefined if node has no parent.
		//! Use parent() to test if node has a parent.
		//! \param name Name of sibling to find, or 0 to return next sibling regardless of its name; this string doesn't have to be zero-terminated if name_size is non-zero
		//! \param name_size Size of name, in characters, or 0 to have size calculated automatically from string
		//! \param case_sensitive Should name comparison be case-sensitive; non case-sensitive comparison works properly only for ASCII characters
		//! \return Pointer to found sibling, or 0 if not found.
		public xml_node<Ch> *next_sibling(Ch name, std.int name_size)
		{
			return next_sibling(name, name_size, true);
		}
		public xml_node<Ch> *next_sibling(Ch name)
		{
			return next_sibling(name, 0, true);
		}
		public xml_node<Ch> *next_sibling()
		{
			return next_sibling(0, 0, true);
		}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: xml_node<Ch> *next_sibling(const Ch *name = 0, std::int name_size = 0, bool case_sensitive = true) const
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
		public xml_node<Ch> *next_sibling(Ch name, std.int name_size, bool case_sensitive)
		{
			Debug.Assert(this.m_parent); // Cannot query for siblings if node has no parent
			if (name != null)
			{
				if (name_size == 0)
					name_size = GlobalMembersProceduralSVG.measure(name);
				for (xml_node<Ch> sibling = m_next_sibling; sibling; sibling = sibling.m_next_sibling)
					if (GlobalMembersProceduralSVG.compare(sibling.name(), sibling.name_size(), name, name_size, case_sensitive) != 0)
						return sibling;
				return 0;
			}
			else
				return m_next_sibling;
		}

		//! Gets first attribute of node, optionally matching attribute name.
		//! \param name Name of attribute to find, or 0 to return first attribute regardless of its name; this string doesn't have to be zero-terminated if name_size is non-zero
		//! \param name_size Size of name, in characters, or 0 to have size calculated automatically from string
		//! \param case_sensitive Should name comparison be case-sensitive; non case-sensitive comparison works properly only for ASCII characters
		//! \return Pointer to found attribute, or 0 if not found.
		public xml_attribute<Ch> *first_attribute(Ch name, std.int name_size)
		{
			return first_attribute(name, name_size, true);
		}
		public xml_attribute<Ch> *first_attribute(Ch name)
		{
			return first_attribute(name, 0, true);
		}
		public xml_attribute<Ch> *first_attribute()
		{
			return first_attribute(0, 0, true);
		}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: xml_attribute<Ch> *first_attribute(const Ch *name = 0, std::int name_size = 0, bool case_sensitive = true) const
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
		public xml_attribute<Ch> *first_attribute(Ch name, std.int name_size, bool case_sensitive)
		{
			if (name != null)
			{
				if (name_size == 0)
					name_size = GlobalMembersProceduralSVG.measure(name);
				for (xml_attribute<Ch> attribute = m_first_attribute; attribute; attribute = attribute.m_next_attribute)
					if (GlobalMembersProceduralSVG.compare(attribute.name(), attribute.name_size(), name, name_size, case_sensitive) != 0)
						return attribute;
				return 0;
			}
			else
				return m_first_attribute;
		}

		//! Gets last attribute of node, optionally matching attribute name.
		//! \param name Name of attribute to find, or 0 to return last attribute regardless of its name; this string doesn't have to be zero-terminated if name_size is non-zero
		//! \param name_size Size of name, in characters, or 0 to have size calculated automatically from string
		//! \param case_sensitive Should name comparison be case-sensitive; non case-sensitive comparison works properly only for ASCII characters
		//! \return Pointer to found attribute, or 0 if not found.
		public xml_attribute<Ch> *last_attribute(Ch name, std.int name_size)
		{
			return last_attribute(name, name_size, true);
		}
		public xml_attribute<Ch> *last_attribute(Ch name)
		{
			return last_attribute(name, 0, true);
		}
		public xml_attribute<Ch> *last_attribute()
		{
			return last_attribute(0, 0, true);
		}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: xml_attribute<Ch> *last_attribute(const Ch *name = 0, std::int name_size = 0, bool case_sensitive = true) const
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
		public xml_attribute<Ch> *last_attribute(Ch name, std.int name_size, bool case_sensitive)
		{
			if (name != null)
			{
				if (name_size == 0)
					name_size = GlobalMembersProceduralSVG.measure(name);
				for (xml_attribute<Ch> attribute = m_last_attribute; attribute; attribute = attribute.m_prev_attribute)
					if (GlobalMembersProceduralSVG.compare(attribute.name(), attribute.name_size(), name, name_size, case_sensitive) != 0)
						return attribute;
				return 0;
			}
			else
				return m_first_attribute != null ? m_last_attribute : 0;
		}

		///////////////////////////////////////////////////////////////////////////
		// Node modification

		//! Sets type of node.
		//! \param type Type of node to set.
		public void type(node_type type)
		{
			m_type = type;
		}

		///////////////////////////////////////////////////////////////////////////
		// Node manipulation

		//! Prepends a new child node.
		//! The prepended child becomes the first child, and all existing children are moved one position back.
		//! \param child Node to prepend.
		public void prepend_node(xml_node<Ch> child)
		{
			Debug.Assert(child != null && !child.parent() && child.type() != (int)node_type.node_document);
			if (first_node())
			{
				child.m_next_sibling = m_first_node;
				m_first_node.m_prev_sibling = child;
			}
			else
			{
				child.m_next_sibling = 0;
				m_last_node = child;
			}
			m_first_node = child;
			child.m_parent = this;
			child.m_prev_sibling = 0;
		}

		//! Appends a new child node. 
		//! The appended child becomes the last child.
		//! \param child Node to append.
		public void append_node(xml_node<Ch> child)
		{
			Debug.Assert(child != null && !child.parent() && child.type() != (int)node_type.node_document);
			if (first_node())
			{
				child.m_prev_sibling = m_last_node;
				m_last_node.m_next_sibling = child;
			}
			else
			{
				child.m_prev_sibling = 0;
				m_first_node = child;
			}
			m_last_node = child;
			child.m_parent = this;
			child.m_next_sibling = 0;
		}

		//! Inserts a new child node at specified place inside the node. 
		//! All children after and including the specified node are moved one position back.
		//! \param where Place where to insert the child, or 0 to insert at the back.
		//! \param child Node to insert.
		public void insert_node(xml_node<Ch> @where, xml_node<Ch> child)
		{
			Debug.Assert(@where == null || @where.parent() == this);
			Debug.Assert(child != null && !child.parent() && child.type() != (int)node_type.node_document);
			if (@where == m_first_node)
				prepend_node(child);
			else if (@where == 0)
				append_node(child);
			else
			{
				child.m_prev_sibling = @where.m_prev_sibling;
				child.m_next_sibling = @where;
				@where.m_prev_sibling.m_next_sibling = child;
				@where.m_prev_sibling = child;
				child.m_parent = this;
			}
		}

		//! Removes first child node. 
		//! If node has no children, behaviour is undefined.
		//! Use first_node() to test if node has children.
		public void remove_first_node()
		{
			Debug.Assert(first_node());
			xml_node<Ch> child = m_first_node;
			m_first_node = child.m_next_sibling;
			if (child.m_next_sibling)
				child.m_next_sibling.m_prev_sibling = 0;
			else
				m_last_node = 0;
			child.m_parent = 0;
		}

		//! Removes last child of the node. 
		//! If node has no children, behaviour is undefined.
		//! Use first_node() to test if node has children.
		public void remove_last_node()
		{
			Debug.Assert(first_node());
			xml_node<Ch> child = m_last_node;
			if (child.m_prev_sibling)
			{
				m_last_node = child.m_prev_sibling;
				child.m_prev_sibling.m_next_sibling = 0;
			}
			else
				m_first_node = 0;
			child.m_parent = 0;
		}

		//! Removes specified child from the node
		// \param where Pointer to child to be removed.
		public void remove_node(xml_node<Ch> @where)
		{
			Debug.Assert(@where != null && @where.parent() == this);
			Debug.Assert(first_node());
			if (@where == m_first_node)
				remove_first_node();
			else if (@where == m_last_node)
				remove_last_node();
			else
			{
				@where.m_prev_sibling.m_next_sibling = @where.m_next_sibling;
				@where.m_next_sibling.m_prev_sibling = @where.m_prev_sibling;
				@where.m_parent = 0;
			}
		}

		//! Removes all child nodes (but not attributes).
		public void remove_all_nodes()
		{
			for (xml_node<Ch> node = first_node(); node; node = node.m_next_sibling)
				node.m_parent = 0;
			m_first_node = 0;
		}

		//! Prepends a new attribute to the node.
		//! \param attribute Attribute to prepend.
		public void prepend_attribute(xml_attribute<Ch> attribute)
		{
			Debug.Assert(attribute != null && !attribute.parent());
			if (first_attribute())
			{
				attribute.m_next_attribute = m_first_attribute;
				m_first_attribute.m_prev_attribute = attribute;
			}
			else
			{
				attribute.m_next_attribute = 0;
				m_last_attribute = attribute;
			}
			m_first_attribute = attribute;
			attribute.m_parent = this;
			attribute.m_prev_attribute = 0;
		}

		//! Appends a new attribute to the node.
		//! \param attribute Attribute to append.
		public void append_attribute(xml_attribute<Ch> attribute)
		{
			Debug.Assert(attribute != null && !attribute.parent());
			if (first_attribute())
			{
				attribute.m_prev_attribute = m_last_attribute;
				m_last_attribute.m_next_attribute = attribute;
			}
			else
			{
				attribute.m_prev_attribute = 0;
				m_first_attribute = attribute;
			}
			m_last_attribute = attribute;
			attribute.m_parent = this;
			attribute.m_next_attribute = 0;
		}

		//! Inserts a new attribute at specified place inside the node. 
		//! All attributes after and including the specified attribute are moved one position back.
		//! \param where Place where to insert the attribute, or 0 to insert at the back.
		//! \param attribute Attribute to insert.
		public void insert_attribute(xml_attribute<Ch> @where, xml_attribute<Ch> attribute)
		{
			Debug.Assert(@where == null || @where.parent() == this);
			Debug.Assert(attribute != null && !attribute.parent());
			if (@where == m_first_attribute)
				prepend_attribute(attribute);
			else if (@where == 0)
				append_attribute(attribute);
			else
			{
				attribute.m_prev_attribute = @where.m_prev_attribute;
				attribute.m_next_attribute = @where;
				@where.m_prev_attribute.m_next_attribute = attribute;
				@where.m_prev_attribute = attribute;
				attribute.m_parent = this;
			}
		}

		//! Removes first attribute of the node. 
		//! If node has no attributes, behaviour is undefined.
		//! Use first_attribute() to test if node has attributes.
		public void remove_first_attribute()
		{
			Debug.Assert(first_attribute());
			xml_attribute<Ch> attribute = m_first_attribute;
			if (attribute.m_next_attribute)
			{
				attribute.m_next_attribute.m_prev_attribute = 0;
			}
			else
				m_last_attribute = 0;
			attribute.m_parent = 0;
			m_first_attribute = attribute.m_next_attribute;
		}

		//! Removes last attribute of the node. 
		//! If node has no attributes, behaviour is undefined.
		//! Use first_attribute() to test if node has attributes.
		public void remove_last_attribute()
		{
			Debug.Assert(first_attribute());
			xml_attribute<Ch> attribute = m_last_attribute;
			if (attribute.m_prev_attribute)
			{
				attribute.m_prev_attribute.m_next_attribute = 0;
				m_last_attribute = attribute.m_prev_attribute;
			}
			else
				m_first_attribute = 0;
			attribute.m_parent = 0;
		}

		//! Removes specified attribute from node.
		//! \param where Pointer to attribute to be removed.
		public void remove_attribute(xml_attribute<Ch> @where)
		{
			Debug.Assert(first_attribute() && @where.parent() == this);
			if (@where == m_first_attribute)
				remove_first_attribute();
			else if (@where == m_last_attribute)
				remove_last_attribute();
			else
			{
				@where.m_prev_attribute.m_next_attribute = @where.m_next_attribute;
				@where.m_next_attribute.m_prev_attribute = @where.m_prev_attribute;
				@where.m_parent = 0;
			}
		}

		//! Removes all attributes of node.
		public void remove_all_attributes()
		{
			for (xml_attribute<Ch> attribute = first_attribute(); attribute; attribute = attribute.m_next_attribute)
				attribute.m_parent = 0;
			m_first_attribute = 0;
		}


		///////////////////////////////////////////////////////////////////////////
		// Restrictions

		// No copying
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//		xml_node(xml_node NamelessParameter);
//C++ TO C# CONVERTER NOTE: This 'CopyFrom' method was converted from the original C++ copy assignment operator:
//ORIGINAL LINE: void operator =(const xml_node &);
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//		void CopyFrom(xml_node NamelessParameter);

		///////////////////////////////////////////////////////////////////////////
		// Data members

		// Note that some of the pointers below have UNDEFINED values if certain other pointers are 0.
		// This is required for maximum performance, as it allows the parser to omit initialization of 
		// unneded/redundant values.
		//
		// The rules are as follows:
		// 1. first_node and first_attribute contain valid pointers, or 0 if node has no children/attributes respectively
		// 2. last_node and last_attribute are valid only if node has at least one child/attribute respectively, otherwise they contain garbage
		// 3. prev_sibling and next_sibling are valid only if node has a parent, otherwise they contain garbage

		private node_type m_type; // Type of node; always valid
		private xml_node<Ch> m_first_node; // Pointer to first child node, or 0 if none; always valid
		private xml_node<Ch> m_last_node; // Pointer to last child node, or 0 if none; this value is only valid if m_first_node is non-zero
		private xml_attribute<Ch> m_first_attribute; // Pointer to first attribute of node, or 0 if none; always valid
		private xml_attribute<Ch> m_last_attribute; // Pointer to last attribute of node, or 0 if none; this value is only valid if m_first_attribute is non-zero
		private xml_node<Ch> m_prev_sibling; // Pointer to previous sibling of node, or 0 if none; this value is only valid if m_parent is non-zero
		private xml_node<Ch> m_next_sibling; // Pointer to next sibling of node, or 0 if none; this value is only valid if m_parent is non-zero

	}
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers containing defaults cannot be converted to C#:
//ORIGINAL LINE: template<class Ch = sbyte>

	///////////////////////////////////////////////////////////////////////////
	// XML document

	//! This class represents root of the DOM hierarchy. 
	//! It is also an xml_node and a memory_pool through public inheritance.
	//! Use parse() function to build a DOM tree from a zero-terminated XML text string.
	//! parse() function allocates memory for nodes and attributes by using functions of xml_document, 
	//! which are inherited from memory_pool.
	//! To access root node of the document, use the document itself, as if it was an xml_node.
	//! \param Ch Character type to use.
	public class xml_document<Ch = sbyte>: xml_node<Ch>, memory_pool<Ch>
	{


		//! Constructs empty XML document
		public xml_document() : base(node_type.node_document)
		{
		}

		//! Parses zero-terminated XML string according to given flags.
		//! Passed string will be modified by the parser, unless rapidxml::parse_non_destructive flag is used.
		//! The string must persist for the lifetime of the document.
		//! In case of error, rapidxml::parse_error exception will be thrown.
		//! <br><br>
		//! If you want to parse contents of a file, you must first load the file into the memory, and pass pointer to its beginning.
		//! Make sure that data is zero-terminated.
		//! <br><br>
		//! Document can be parsed into multiple times. 
		//! Each new call to parse removes previous nodes and attributes (if any), but does not clear memory pool.
		//! \param text XML data to parse; pointer is non-const to denote fact that this data may be modified by the parser.
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Flags>
		public void parse<int Flags>(ref Ch text)
		{
			Debug.Assert(text);

			// Remove current contents
			this.remove_all_nodes();
			this.remove_all_attributes();

			// Parse BOM, if any
			parse_bom<Flags>(text);

			// Parse children
			while (1)
			{
				// Skip whitespace before node
				skip<whitespace_pred, Flags>(text);
				if ( text == 0)
					break;

				// Parse and append new child
				if ( text == Ch('<'))
				{
					++text; // Skip '<'
					if (xml_node<Ch> *node = parse_node<Flags>(text))
						this.append_node(node);
				}
				else
					RAPIDXML_PARSE_ERROR("expected <", text);
			}

		}

		//! Clears the document by deleting all nodes and clearing the memory pool.
		//! All nodes owned by document pool are destroyed.
		public void clear()
		{
			this.remove_all_nodes();
			this.remove_all_attributes();
			memory_pool<Ch>.clear();
		}


		///////////////////////////////////////////////////////////////////////
		// Internal character utility functions

		// Detect whitespace character
		private class whitespace_pred
		{
			public static byte test(Ch ch)
			{
				return GlobalMembersProceduralSVG.lookup_tables<0>.lookup_whitespace[(byte)(ch)];
			}
		}

		// Detect node name character
		private class node_name_pred
		{
			public static byte test(Ch ch)
			{
				return GlobalMembersProceduralSVG.lookup_tables<0>.lookup_node_name[(byte)(ch)];
			}
		}

		// Detect attribute name character
		private class attribute_name_pred
		{
			public static byte test(Ch ch)
			{
				return GlobalMembersProceduralSVG.lookup_tables<0>.lookup_attribute_name[(byte)(ch)];
			}
		}

		// Detect text character (PCDATA)
		private class text_pred
		{
			public static byte test(Ch ch)
			{
				return GlobalMembersProceduralSVG.lookup_tables<0>.lookup_text[(byte)(ch)];
			}
		}

		// Detect text character (PCDATA) that does not require processing
		private class text_pure_no_ws_pred
		{
			public static byte test(Ch ch)
			{
				return GlobalMembersProceduralSVG.lookup_tables<0>.lookup_text_pure_no_ws[(byte)(ch)];
			}
		}

		// Detect text character (PCDATA) that does not require processing
		private class text_pure_with_ws_pred
		{
			public static byte test(Ch ch)
			{
				return GlobalMembersProceduralSVG.lookup_tables<0>.lookup_text_pure_with_ws[(byte)(ch)];
			}
		}

		// Detect attribute value character
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<Ch Quote>
		private class attribute_value_pred <Ch Quote>
		{
			public static byte test(Ch ch)
			{
				if (Quote == Ch('\''))
					return GlobalMembersProceduralSVG.lookup_tables<0>.lookup_attribute_data_1[(byte)(ch)];
				if (Quote == Ch('\"'))
					return GlobalMembersProceduralSVG.lookup_tables<0>.lookup_attribute_data_2[(byte)(ch)];
				return 0; // Should never be executed, to avoid warnings on Comeau
			}
		}

		// Detect attribute value character
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<Ch Quote>
		private class attribute_value_pure_pred <Ch Quote>
		{
			public static byte test(Ch ch)
			{
				if (Quote == Ch('\''))
					return GlobalMembersProceduralSVG.lookup_tables<0>.lookup_attribute_data_1_pure[(byte)(ch)];
				if (Quote == Ch('\"'))
					return GlobalMembersProceduralSVG.lookup_tables<0>.lookup_attribute_data_2_pure[(byte)(ch)];
				return 0; // Should never be executed, to avoid warnings on Comeau
			}
		}

		// Insert coded character, using UTF8 or 8-bit ASCII
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Flags>
		private static void insert_coded_character<int Flags>(ref Ch[] text, uint code)
		{
			if (Flags & GlobalMembersProceduralSVG.parse_no_utf8)
			{
				// Insert 8-bit ASCII character
				// Todo: possibly verify that code is less than 256 and use replacement char otherwise?
				text[0] = (byte)(code);
				text += 1;
			}
			else
			{
				// Insert UTF8 sequence
				if (code < 0x80) // 1 byte sequence
				{
					text[0] = (byte)(code);
					text += 1;
				}
				else if (code < 0x800) // 2 byte sequence
				{
					text[1] = (byte)((code | 0x80) & 0xBF);
					code >>= 6;
					text[0] = (byte)(code | 0xC0);
					text += 2;
				}
				else if (code < 0x10000) // 3 byte sequence
				{
					text[2] = (byte)((code | 0x80) & 0xBF);
					code >>= 6;
					text[1] = (byte)((code | 0x80) & 0xBF);
					code >>= 6;
					text[0] = (byte)(code | 0xE0);
					text += 3;
				}
				else if (code < 0x110000) // 4 byte sequence
				{
					text[3] = (byte)((code | 0x80) & 0xBF);
					code >>= 6;
					text[2] = (byte)((code | 0x80) & 0xBF);
					code >>= 6;
					text[1] = (byte)((code | 0x80) & 0xBF);
					code >>= 6;
					text[0] = (byte)(code | 0xF0);
					text += 4;
				}
				else // Invalid, only codes up to 0x10FFFF are allowed in Unicode
				{
					RAPIDXML_PARSE_ERROR("invalid numeric character entity", text);
				}
			}
		}

		// Skip characters until predicate evaluates to true
//C++ TO C# CONVERTER TODO TASK: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class StopPred, int Flags>
		private static void skip<StopPred, int Flags>(ref Ch text)
		{
//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on this variable, so pointers on this variable are left unchanged.
			Ch *tmp = text;
			while (StopPred.test(*tmp))
				++tmp;
			text = tmp;
		}

		// Skip characters until predicate evaluates to true while doing the following:
		// - replacing XML character entity references with proper characters (&apos; &amp; &quot; &lt; &gt; &#...;)
		// - condensing whitespace sequences to single space character
//C++ TO C# CONVERTER TODO TASK: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class StopPred, class StopPredPure, int Flags>
		private static Ch skip_and_expand_character_refs<StopPred, StopPredPure, int Flags>(ref Ch text)
		{
			// If entity translation, whitespace condense and whitespace trimming is disabled, use plain skip
			if (Flags & GlobalMembersProceduralSVG.parse_no_entity_translation && !(Flags & GlobalMembersProceduralSVG.parse_normalize_whitespace) && !(Flags & GlobalMembersProceduralSVG.parse_trim_whitespace))
			{
				skip<StopPred, Flags>(text);
				return text;
			}

			// Use simple skip until first modification is detected
			skip<StopPredPure, Flags>(text);

			// Use translation skip
			Ch[] src = text;
//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on this variable, so pointers on this variable are left unchanged.
			Ch *dest = src;
			while (StopPred.test(*src))
			{
				// If entity translation is enabled    
				if (!(Flags & GlobalMembersProceduralSVG.parse_no_entity_translation))
				{
					// Test if replacement is needed
					if (src[0] == Ch('&'))
					{
						switch (src[1])
						{

						// &amp; &apos;
						case Ch('a'):
							if (src[2] == Ch('m') && src[3] == Ch('p') && src[4] == Ch(';'))
							{
								*dest = Ch('&');
								++dest;
								src += 5;
								continue;
							}
							if (src[2] == Ch('p') && src[3] == Ch('o') && src[4] == Ch('s') && src[5] == Ch(';'))
							{
								*dest = Ch('\'');
								++dest;
								src += 6;
								continue;
							}
							break;

						// &quot;
						case Ch('q'):
							if (src[2] == Ch('u') && src[3] == Ch('o') && src[4] == Ch('t') && src[5] == Ch(';'))
							{
								*dest = Ch('"');
								++dest;
								src += 6;
								continue;
							}
							break;

						// &gt;
						case Ch('g'):
							if (src[2] == Ch('t') && src[3] == Ch(';'))
							{
								*dest = Ch('>');
								++dest;
								src += 4;
								continue;
							}
							break;

						// &lt;
						case Ch('l'):
							if (src[2] == Ch('t') && src[3] == Ch(';'))
							{
								*dest = Ch('<');
								++dest;
								src += 4;
								continue;
							}
							break;

						// &#...; - assumes ASCII
						case Ch('#'):
							if (src[2] == Ch('x'))
							{
								uint code = 0;
								src += 3; // Skip &#x
								while (1)
								{
									byte digit = GlobalMembersProceduralSVG.lookup_tables<0>.lookup_digits[(byte)(*src)];
									if (digit == 0xFF)
										break;
									code = code * 16 + digit;
									++src;
								}
								insert_coded_character<Flags>(dest, code); // Put character in output
							}
							else
							{
								uint code = 0;
								src += 2; // Skip &#
								while (1)
								{
									byte digit = GlobalMembersProceduralSVG.lookup_tables<0>.lookup_digits[(byte)(*src)];
									if (digit == 0xFF)
										break;
									code = code * 10 + digit;
									++src;
								}
								insert_coded_character<Flags>(dest, code); // Put character in output
							}
							if (*src == Ch(';'))
								++src;
							else
								RAPIDXML_PARSE_ERROR("expected ;", src);
							continue;

						// Something else
						default:
							// Ignore, just copy '&' verbatim
							break;

						}
					}
				}

				// If whitespace condensing is enabled
				if (Flags & GlobalMembersProceduralSVG.parse_normalize_whitespace)
				{
					// Test if condensing is needed                 
					if (whitespace_pred.test(*src))
					{
						*dest = Ch(' '); // Put single space in dest
						++dest;
						++src; // Skip first whitespace char
						// Skip remaining whitespace chars
						while (whitespace_pred.test(*src))
							++src;
						continue;
					}
				}

				// No replacement, only copy character
				*dest++= *src++;

			}

			// Return new end
			text = src;
			return dest;

		}

		///////////////////////////////////////////////////////////////////////
		// Internal parsing functions

		// Parse BOM, if any
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Flags>
		private void parse_bom<int Flags>(ref Ch[] text)
		{
			// UTF-8?
			if ((byte)(text[0]) == 0xEF && (byte)(text[1]) == 0xBB && (byte)(text[2]) == 0xBF)
			{
				text += 3; // Skup utf-8 bom
			}
		}

		// Parse XML declaration (<?xml...)
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Flags>
		private xml_node<Ch> *parse_xml_declaration<int Flags>(ref Ch[] text)
		{
			// If parsing of declaration is disabled
			if (!(Flags & GlobalMembersProceduralSVG.parse_declaration_node))
			{
				// Skip until end of declaration
				while (text[0] != Ch('?') || text[1] != Ch('>'))
				{
					if (!text[0])
						RAPIDXML_PARSE_ERROR("unexpected end of data", text);
					++text;
				}
				text += 2; // Skip '?>'
				return 0;
			}

			// Create declaration
			xml_node<Ch> declaration = this.allocate_node(node_type.node_declaration);

			// Skip whitespace before attributes or ?>
			skip<whitespace_pred, Flags>(text);

			// Parse declaration attributes
			parse_node_attributes<Flags>(text, declaration);

			// Skip ?>
			if (text[0] != Ch('?') || text[1] != Ch('>'))
				RAPIDXML_PARSE_ERROR("expected ?>", text);
			text += 2;

			return declaration;
		}

		// Parse XML comment (<!--...)
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Flags>
		private xml_node<Ch> *parse_comment<int Flags>(ref Ch[] text)
		{
			// If parsing of comments is disabled
			if (!(Flags & GlobalMembersProceduralSVG.parse_comment_nodes))
			{
				// Skip until end of comment
				while (text[0] != Ch('-') || text[1] != Ch('-') || text[2] != Ch('>'))
				{
					if (!text[0])
						RAPIDXML_PARSE_ERROR("unexpected end of data", text);
					++text;
				}
				text += 3; // Skip '-->'
				return 0; // Do not produce comment node
			}

			// Remember value start
			Ch @value = text;

			// Skip until end of comment
			while (text[0] != Ch('-') || text[1] != Ch('-') || text[2] != Ch('>'))
			{
				if (!text[0])
					RAPIDXML_PARSE_ERROR("unexpected end of data", text);
				++text;
			}

			// Create comment node
			xml_node<Ch> comment = this.allocate_node(node_type.node_comment);
			comment.@value(@value, text - @value);

			// Place zero terminator after comment value
			if (!(Flags & GlobalMembersProceduralSVG.parse_no_string_terminators))
				*text = Ch('\0');

			text += 3; // Skip '-->'
			return comment;
		}

		// Parse DOCTYPE
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Flags>
		private xml_node<Ch> *parse_doctype<int Flags>(ref Ch text)
		{
			// Remember value start
			Ch @value = text;

			// Skip to >
			while ( text != Ch('>'))
			{
				// Determine character type
				switch ( text)
				{

				// If '[' encountered, scan for matching ending ']' using naive algorithm with depth
				// This works for all W3C test files except for 2 most wicked
				case Ch('['):
				{
					++text; // Skip '['
					int depth = 1;
					while (depth > 0)
					{
						switch ( text)
						{
							case Ch('['):
								++depth;
								break;
							case Ch(']'):
								--depth;
								break;
							case 0:
								RAPIDXML_PARSE_ERROR("unexpected end of data", text);
								break;
						}
						++text;
					}
					break;
				}

				// Error on end of text
				case Ch('\0'):
					RAPIDXML_PARSE_ERROR("unexpected end of data", text);

				// Other character, skip it
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
				default:
					++text;

					break;
				}
			}

			// If DOCTYPE nodes enabled
			if (Flags & GlobalMembersProceduralSVG.parse_doctype_node)
			{
				// Create a new doctype node
				xml_node<Ch> doctype = this.allocate_node(node_type.node_doctype);
				doctype.@value(@value, text - @value);

				// Place zero terminator after value
				if (!(Flags & GlobalMembersProceduralSVG.parse_no_string_terminators))
					text = Ch('\0');

				text += 1; // skip '>'
				return doctype;
			}
			else
			{
				text += 1; // skip '>'
				return 0;
			}

		}

		// Parse PI
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Flags>
		private xml_node<Ch> *parse_pi<int Flags>(ref Ch[] text)
		{
			// If creation of PI nodes is enabled
			if (Flags & GlobalMembersProceduralSVG.parse_pi_nodes)
			{
				// Create pi node
				xml_node<Ch> pi = this.allocate_node(node_type.node_pi);

				// Extract PI target name
				Ch name = text;
				skip<node_name_pred, Flags>(text);
				if (text == name)
					RAPIDXML_PARSE_ERROR("expected PI target", text);
				pi.name(name, text - name);

				// Skip whitespace between pi target and pi
				skip<whitespace_pred, Flags>(text);

				// Remember start of pi
				Ch @value = text;

				// Skip to '?>'
				while (text[0] != Ch('?') || text[1] != Ch('>'))
				{
					if (*text == Ch('\0'))
						RAPIDXML_PARSE_ERROR("unexpected end of data", text);
					++text;
				}

				// Set pi value (verbatim, no entity expansion or whitespace normalization)
				pi.@value(@value, text - @value);

				// Place zero terminator after name and value
				if (!(Flags & GlobalMembersProceduralSVG.parse_no_string_terminators))
				{
					pi.name()[pi.name_size()] = Ch('\0');
					pi.@value()[pi.value_size()] = Ch('\0');
				}

				text += 2; // Skip '?>'
				return pi;
			}
			else
			{
				// Skip to '?>'
				while (text[0] != Ch('?') || text[1] != Ch('>'))
				{
					if (*text == Ch('\0'))
						RAPIDXML_PARSE_ERROR("unexpected end of data", text);
					++text;
				}
				text += 2; // Skip '?>'
				return 0;
			}
		}

		// Parse and append data
		// Return character that ends data.
		// This is necessary because this character might have been overwritten by a terminating 0
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Flags>
		private Ch parse_and_append_data<int Flags>(xml_node<Ch> node, ref Ch text, ref Ch contents_start)
		{
			// Backup to contents start if whitespace trimming is disabled
			if (!(Flags & GlobalMembersProceduralSVG.parse_trim_whitespace))
				text = contents_start;

			// Skip until end of data
			Ch @value = text;
//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on this variable, so pointers on this variable are left unchanged.
			Ch *end = new Ch();
			if (Flags & GlobalMembersProceduralSVG.parse_normalize_whitespace)
				end = skip_and_expand_character_refs<text_pred, text_pure_with_ws_pred, Flags>(text);
			else
				end = skip_and_expand_character_refs<text_pred, text_pure_no_ws_pred, Flags>(text);

			// Trim trailing whitespace if flag is set; leading was already trimmed by whitespace skip after >
			if (Flags & GlobalMembersProceduralSVG.parse_trim_whitespace)
			{
				if (Flags & GlobalMembersProceduralSVG.parse_normalize_whitespace)
				{
					// Whitespace is already condensed to single space characters by skipping function, so just trim 1 char off the end
					if (*(end - 1) == Ch(' '))
						--end;
				}
				else
				{
					// Backup until non-whitespace character is found
					while (whitespace_pred.test(*(end - 1)))
						--end;
				}
			}

			// If characters are still left between end and value (this test is only necessary if normalization is enabled)
			// Create new data node
			if (!(Flags & GlobalMembersProceduralSVG.parse_no_data_nodes))
			{
				xml_node<Ch> data = this.allocate_node(node_type.node_data);
				data.@value(@value, end - @value);
				node.append_node(data);
			}

			// Add data to parent node if no data exists yet
			if (!(Flags & GlobalMembersProceduralSVG.parse_no_element_values))
				if ( node.@value() == Ch('\0'))
					node.@value(@value, end - @value);

			// Place zero terminator after value
			if (!(Flags & GlobalMembersProceduralSVG.parse_no_string_terminators))
			{
				Ch ch = text;
				*end = Ch('\0');
				return ch; // Return character that ends data; this is required because zero terminator overwritten it
			}

			// Return character that ends data
			return text;
		}

		// Parse CDATA
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Flags>
		private xml_node<Ch> *parse_cdata<int Flags>(ref Ch[] text)
		{
			// If CDATA is disabled
			if (Flags & GlobalMembersProceduralSVG.parse_no_data_nodes)
			{
				// Skip until end of cdata
				while (text[0] != Ch(']') || text[1] != Ch(']') || text[2] != Ch('>'))
				{
					if (!text[0])
						RAPIDXML_PARSE_ERROR("unexpected end of data", text);
					++text;
				}
				text += 3; // Skip ]]>
				return 0; // Do not produce CDATA node
			}

			// Skip until end of cdata
			Ch @value = text;
			while (text[0] != Ch(']') || text[1] != Ch(']') || text[2] != Ch('>'))
			{
				if (!text[0])
					RAPIDXML_PARSE_ERROR("unexpected end of data", text);
				++text;
			}

			// Create new cdata node
			xml_node<Ch> cdata = this.allocate_node(node_type.node_cdata);
			cdata.@value(@value, text - @value);

			// Place zero terminator after value
			if (!(Flags & GlobalMembersProceduralSVG.parse_no_string_terminators))
				*text = Ch('\0');

			text += 3; // Skip ]]>
			return cdata;
		}

		// Parse element node
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Flags>
		private xml_node<Ch> *parse_element<int Flags>(ref Ch text)
		{
			// Create element node
			xml_node<Ch> element = this.allocate_node(node_type.node_element);

			// Extract element name
			Ch name = text;
			skip<node_name_pred, Flags>(text);
			if (text == name)
				RAPIDXML_PARSE_ERROR("expected element name", text);
			element.name(name, text - name);

			// Skip whitespace between element name and attributes or >
			skip<whitespace_pred, Flags>(text);

			// Parse attributes, if any
			parse_node_attributes<Flags>(text, element);

			// Determine ending type
			if ( text == Ch('>'))
			{
				++text;
				parse_node_contents<Flags>(text, element);
			}
			else if ( text == Ch('/'))
			{
				++text;
				if ( text != Ch('>'))
					RAPIDXML_PARSE_ERROR("expected >", text);
				++text;
			}
			else
				RAPIDXML_PARSE_ERROR("expected >", text);

			// Place zero terminator after name
			if (!(Flags & GlobalMembersProceduralSVG.parse_no_string_terminators))
				element.name()[element.name_size()] = Ch('\0');

			// Return parsed element
			return element;
		}

		// Determine node type, and parse it
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Flags>
		private xml_node<Ch> *parse_node<int Flags>(ref Ch[] text)
		{
			// Parse proper node type
			switch (text[0])
			{

			// <...
			default:
				// Parse and append element node
				return parse_element<Flags>(text);

			// <?...
			case Ch('?'):
				++text; // Skip ?
				if ((text[0] == Ch('x') || text[0] == Ch('X')) && (text[1] == Ch('m') || text[1] == Ch('M')) && (text[2] == Ch('l') || text[2] == Ch('L')) && whitespace_pred.test(text[3]))
				{
					// '<?xml ' - xml declaration
					text += 4; // Skip 'xml '
					return parse_xml_declaration<Flags>(text);
				}
				else
				{
					// Parse PI
					return parse_pi<Flags>(text);
				}

			// <!...
			case Ch('!'):

				// Parse proper subset of <! node
				switch (text[1])
				{

				// <!-
				case Ch('-'):
					if (text[2] == Ch('-'))
					{
						// '<!--' - xml comment
						text += 3; // Skip '!--'
						return parse_comment<Flags>(text);
					}
					break;

				// <![
				case Ch('['):
					if (text[2] == Ch('C') && text[3] == Ch('D') && text[4] == Ch('A') && text[5] == Ch('T') && text[6] == Ch('A') && text[7] == Ch('['))
					{
						// '<![CDATA[' - cdata
						text += 8; // Skip '![CDATA['
						return parse_cdata<Flags>(text);
					}
					break;

				// <!D
				case Ch('D'):
					if (text[2] == Ch('O') && text[3] == Ch('C') && text[4] == Ch('T') && text[5] == Ch('Y') && text[6] == Ch('P') && text[7] == Ch('E') && whitespace_pred.test(text[8]))
					{
						// '<!DOCTYPE ' - doctype
						text += 9; // skip '!DOCTYPE '
						return parse_doctype<Flags>(text);
					}

				} // switch

				// Attempt to skip other, unrecognized node types starting with <!
				++text; // Skip !
				while (*text != Ch('>'))
				{
					if (*text == 0)
						RAPIDXML_PARSE_ERROR("unexpected end of data", text);
					++text;
				}
				++text; // Skip '>'
				return 0; // No node recognized

			}
		}

		// Parse contents of the node - children, data etc.
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Flags>
		private void parse_node_contents<int Flags>(ref Ch[] text, xml_node<Ch> node)
		{
			// For all children and text
			while (1)
			{
				// Skip whitespace between > and node contents
				Ch contents_start = text; // Store start of node contents before whitespace is skipped
				skip<whitespace_pred, Flags>(text);
				Ch next_char = *text;

			// After data nodes, instead of continuing the loop, control jumps here.
			// This is because zero termination inside parse_and_append_data() function
			// would wreak havoc with the above code.
			// Also, skipping whitespace after data nodes is unnecessary.
			after_data_node:

				// Determine what comes next: node closing, child node, data node, or 0?
				switch (next_char)
				{

				// Node closing or child node
				case Ch('<'):
					if (text[1] == Ch('/'))
					{
						// Node closing
						text += 2; // Skip '</'
						if (Flags & GlobalMembersProceduralSVG.parse_validate_closing_tags)
						{
							// Skip and validate closing tag name
							Ch closing_name = text;
							skip<node_name_pred, Flags>(text);
							if (GlobalMembersProceduralSVG.compare(node.name(), node.name_size(), closing_name, text - closing_name, true) == 0)
								RAPIDXML_PARSE_ERROR("invalid closing tag name", text);
						}
						else
						{
							// No validation, just skip name
							skip<node_name_pred, Flags>(text);
						}
						// Skip remaining whitespace after node name
						skip<whitespace_pred, Flags>(text);
						if (*text != Ch('>'))
							RAPIDXML_PARSE_ERROR("expected >", text);
						++text; // Skip '>'
						return; // Node closed, finished parsing contents
					}
					else
					{
						// Child node
						++text; // Skip '<'
						if (xml_node<Ch> *child = parse_node<Flags>(text))
							node.append_node(child);
					}
					break;

				// End of data - error
				case Ch('\0'):
					RAPIDXML_PARSE_ERROR("unexpected end of data", text);

				// Data node
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
				default:
					next_char = parse_and_append_data<Flags>(node, text, contents_start);
					goto after_data_node; // Bypass regular processing after data nodes

				}
			}
		}

		// Parse XML attributes of the node
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Flags>
		private void parse_node_attributes<int Flags>(ref Ch text, xml_node<Ch> node)
		{
			// For all attributes 
			while (attribute_name_pred.test(text))
			{
				// Extract attribute name
				Ch name = text;
				++text; // Skip first character of attribute name
				skip<attribute_name_pred, Flags>(text);
				if (text == name)
					RAPIDXML_PARSE_ERROR("expected attribute name", name);

				// Create new attribute
				xml_attribute<Ch> attribute = this.allocate_attribute();
				attribute.name(name, text - name);
				node.append_attribute(attribute);

				// Skip whitespace after attribute name
				skip<whitespace_pred, Flags>(text);

				// Skip =
				if ( text != Ch('='))
					RAPIDXML_PARSE_ERROR("expected =", text);
				++text;

				// Add terminating zero after name
				if (!(Flags & GlobalMembersProceduralSVG.parse_no_string_terminators))
					attribute.name()[attribute.name_size()] = 0;

				// Skip whitespace after =
				skip<whitespace_pred, Flags>(text);

				// Skip quote and remember if it was ' or "
				Ch quote = text;
				if (quote != Ch('\'') && quote != Ch('"'))
					RAPIDXML_PARSE_ERROR("expected ' or \"", text);
				++text;

				// Extract attribute value and expand char refs in it
				Ch @value = text;
				Ch end;
				const int AttFlags = Flags & ~GlobalMembersProceduralSVG.parse_normalize_whitespace; // No whitespace normalization in attributes
				if (quote == Ch('\''))
					end = skip_and_expand_character_refs<attribute_value_pred<Ch('\'')>, attribute_value_pure_pred<Ch('\'')>, AttFlags>(text);
				else
					end = skip_and_expand_character_refs<attribute_value_pred<Ch('"')>, attribute_value_pure_pred<Ch('"')>, AttFlags>(text);

				// Set attribute value
				attribute.@value(@value, end - @value);

				// Make sure that end quote is present
				if ( text != quote)
					RAPIDXML_PARSE_ERROR("expected ' or \"", text);
				++text; // Skip quote

				// Add terminating zero after value
				if (!(Flags & GlobalMembersProceduralSVG.parse_no_string_terminators))
					attribute.@value()[attribute.value_size()] = 0;

				// Skip whitespace after attribute value
				skip<whitespace_pred, Flags>(text);
			}
		}

	}

	//! \cond internal
	namespace internal
	{
//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int Dummy>
		  // 0,  1,  2,  3,  4,  5,  6,  7,  8,  9,  A   B   C   D   E   F
	}
	//! \endcond

}

// Undefine internal macros
#undef RAPIDXML_PARSE_ERROR

// On MSVC, restore warnings state
#if _MSC_VER
//C++ TO C# CONVERTER TODO TASK: There is no equivalent to most C++ 'pragma' directives in C#:
//    #pragma warning(pop)
#endif

namespace Procedural
{
}

//----------------------------------------------------------------------------------------
//	Copyright ? 2006 - 2009 Tangible Software Solutions Inc.
//	This class can be used by anyone provided that the copyright notice remains intact.
//
//	This class provides miscellaneous helper methods for strings.
//----------------------------------------------------------------------------------------
internal static class StringHelper
{
	//------------------------------------------------------------------------------------
	//	This method allows replacing a single character in a string, to help convert
	//	C++ code where a single character in a character array is replaced.
	//------------------------------------------------------------------------------------
	internal static string ChangeCharacter(string sourcestring, int charindex, char changechar)
	{
		return (charindex > 0 ? sourcestring.Substring(0, charindex) : "")
			+ changechar.ToString() + (charindex < sourcestring.Length - 1 ? sourcestring.Substring(charindex + 1) : "");
	}
}