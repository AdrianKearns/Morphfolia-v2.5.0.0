# Morphfolia-v2.5.0.0
ASP.Net / MS SQL CMS, originally developed and released through CodePlex. Active around 2010, now defunct and posted for reference.

# Architectural Reference

Whilst the code is yonks old, some of the ideas are timeless (not necesarily my specific implementation).  
Proper description of the architecture yet to come, but some of the concepts you mind find useful if they are new to you are:
* Configuration-based Dependency Injection.
* Use of DTOs (Data Transfer Objects) - not project structure & dependencies.

# Original Project Description

Morphfolia is a CMS and web application framework (for the typical Microsoft ASP.NET stack), designed to work in a hosted environment.

## Out-Of-The-Box Features / Capabilities

### CMS / WCM (End User Features)
* Editing: content and page separation (for more flexible management and reuse of content).
* Human and Search engine friendly URLs
* Blogging.
* Dynamic / auto generated site map
* Site Index (just like an index at the back of a text book).
* Tag-clouds auto filled based on content.
* Search engine, with “Google Suggests” type search preview as the search criteria is typed, including page count and word count.
* Web based admin section.
* Real-time Web Stats, including: traffic flow, Dashboards, ability to view individual session “history” and flow, search and export.
* Supports templates for layout, look and feel.
* File and Image Managers for uploading and management of files; auto generates thumbnail images for uploaded images.
* Basic WYSIWYG content editor, with Image Manager and File Manager integration.
* Also allows “forms” to be defined (at dev-time) for capturing data in a “form” rather than “open HTML” format via the WYSIWYG editor.
* User management; support for individual user logins across multiple directories.
* Audit logging

### Framework (Developer Features)
* Purpose built to work in a hosted environment (where you don't have a lot of control over the box), with self-support functionality.
* Http Handler driven - page serving, indicative search results, line charts and pie charts, and more.
* Searchable administrator audit trail.
* Authentication via standard ASP.NET forms authentication.
* User / role support via standard ASP.NET System.Web.Security.SqlRoleProvider, System.Web.Security.SqlMembershipProvider and System.Web.Profile.SqlProfileProvider
* Logging extensive and customizable system logging via Microsoft Enterprise Libraries 3.1; plus online search and extract facility.
* Performance logging via Microsoft Enterprise Libraries 3.1 Tracers.
* Abstracted data access, with a Microsoft SQL 2005 implementation (utilizing the Microsoft Enterprise Libraries data access block).
* Anti XSS provided via Microsoft AntiXSS library.
* XSS and SQL-Injection resistant.
* Multiple integration points: supports (MVC like) HTTP Handlers and WebForms.
* Attribute driven templates and modules.
* Supports addition of templates without recompilation.
* Re-useable custom-property facility.
* Layered architecture.
* Small dependency footprint.
* Library of re-useable web controls (such as Tag-Cloud and Search Input).
* IT operational support pages, including dynamic ‘self documenting’ pages for appSettings and event ids.
