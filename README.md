# Walsh Product Management Service

Welcome to the Walsh Product Management Service! This project is designed to help you manage products effectively by providing features for creating, updating, and handling products in a secure and efficient manner.

## Project Description

The project revolves around the management of products with key functionalities, including:

- **Create:** Add new products to the system.
- **Update:** Modify existing product details.
- **Remove:** Soft delete products by moving them to the trash.
- **Trash:** A temporary holding area for deleted products.
  - **Restore:** Bring a product back from the trash to the product list.
  - **Delete Permanently:** Remove a product permanently from the trash.

The application uses Microsoft SQL Server (MSSQL) as the database, configured for local connection.

## Getting Started

Follow these steps to set up and run the project:

### Prerequisites

- [.NET Core 6 SDK](https://dotnet.microsoft.com/download) installed
- [Node.js](https://nodejs.org/) installed for frontend development (if applicable)
- Microsoft SQL Server installed locally

### Installation

1. **Clone the repository:**

   ```bash
   git clone https://github.com/JoelKap/walsh-product-management-service.git
   cd walsh-product-management-service
