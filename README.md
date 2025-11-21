# Azure-Terraform Operational Tasks Portal

This repository contains an in-house operational tasks portal solution designed to replace the BTA partner portal for CSW (Customer Success Workflow) tasks and implementation.

## 🎯 Project Overview

This project demonstrates the **feasibility and implementation** of developing an operational tasks management portal in-house, eliminating the dependency on external vendor (BTA) contracts while maintaining full control over features and infrastructure.

## 📋 Repository Structure

```
Azure-Terraform/
├── application/                    # Web application
│   └── WebApp/                    # ASP.NET Core web application
│       ├── Models/                # Data models
│       ├── Pages/                 # Razor pages
│       ├── Services/              # Business logic services
│       └── wwwroot/              # Static assets
├── infrastructure/                # Terraform IaC
│   ├── main.tf                   # Azure resource definitions
│   ├── variables.tf              # Variable definitions
│   └── terraform.tfvars          # Variable values
├── FEASIBILITY_ANALYSIS.md       # Detailed feasibility study
└── README.md                     # This file
```

## 🚀 Features

### Operational Tasks Portal

- **Task Management**
  - Create, view, update, and delete operational tasks
  - Task categorization (Database Ops, Security, Configuration, Monitoring, etc.)
  - Priority levels (Critical, High, Medium, Low)
  - Status tracking (Pending, In Progress, Completed, Blocked, Cancelled)
  - Team assignment
  - Due date tracking with overdue highlighting

- **Dashboard & Analytics**
  - Real-time task statistics
  - Visual status indicators
  - Color-coded priority and status badges
  - Task overview table

- **Technical Features**
  - Thread-safe concurrent operations
  - Responsive Bootstrap UI
  - ASP.NET Core 9.0
  - Dependency injection
  - Azure-ready deployment

## 📊 Screenshots

### Home Page
![Home Page](https://github.com/user-attachments/assets/da621d93-6d41-4d83-b7ff-4b9d4a92118a)

### Operational Tasks Dashboard
![Operations Dashboard](https://github.com/user-attachments/assets/c75209f5-1eed-4242-aaa4-32cd9cb19254)

## 🛠️ Technology Stack

- **Frontend**: ASP.NET Core 9.0 Razor Pages, Bootstrap 5
- **Backend**: C# .NET 9.0
- **Infrastructure**: Azure App Service, Azure Resource Groups
- **IaC**: Terraform
- **Concurrency**: ConcurrentDictionary for thread-safe operations

## 🏗️ Getting Started

### Prerequisites

- .NET 9.0 SDK
- Azure subscription (for deployment)
- Terraform (for infrastructure provisioning)

### Running Locally

1. **Clone the repository**
   ```bash
   git clone https://github.com/akhilch396/Azure-Terraform.git
   cd Azure-Terraform
   ```

2. **Build the application**
   ```bash
   cd application/WebApp
   dotnet build
   ```

3. **Run the application**
   ```bash
   dotnet run
   ```

4. **Access the portal**
   - Navigate to `http://localhost:5000`
   - Click on "Operational Tasks" in the navigation menu

### Deploying to Azure

1. **Initialize Terraform**
   ```bash
   cd infrastructure
   terraform init
   ```

2. **Review the deployment plan**
   ```bash
   terraform plan
   ```

3. **Deploy infrastructure**
   ```bash
   terraform apply
   ```

4. **Deploy application**
   ```bash
   cd ../application/WebApp
   dotnet publish -c Release
   # Deploy to Azure App Service using Azure CLI or CI/CD pipeline
   ```

## 📖 Documentation

### Feasibility Analysis

See [FEASIBILITY_ANALYSIS.md](FEASIBILITY_ANALYSIS.md) for a comprehensive analysis including:
- Requirements analysis
- Technical feasibility assessment
- Cost-benefit analysis
- Implementation roadmap
- Risk assessment
- Recommendation

### Key Findings

✅ **Highly Feasible** - The existing technology stack (ASP.NET Core, Azure, Terraform) provides a strong foundation for implementation.

✅ **Cost Effective** - Eliminates recurring BTA contract fees and licensing costs.

✅ **Strategic Value** - Provides better control, customization, and integration capabilities.

✅ **Low Risk** - Proven technology stack with minimal technical challenges.

## 🔒 Security

- Thread-safe operations using ConcurrentDictionary
- No security vulnerabilities detected (CodeQL analysis passed)
- Azure security best practices
- HTTPS enforcement
- Data protection compliance

## 🎨 Customization

The portal is designed to be easily customizable:

- **Add new task categories**: Modify `OperationalTask.cs` model
- **Extend functionality**: Add new pages in `Pages/` directory
- **Integrate with databases**: Replace in-memory storage with Entity Framework Core
- **Add authentication**: Integrate Azure AD or Identity Server
- **API development**: Add API controllers for external integrations

## 📈 Future Enhancements

### Phase 1: MVP (Current)
- ✅ Basic task management
- ✅ Dashboard with statistics
- ✅ Thread-safe operations

### Phase 2: Enhanced Features (Planned)
- [ ] Persistent database storage
- [ ] User authentication and authorization
- [ ] Email notifications
- [ ] Advanced filtering and search
- [ ] Task analytics and reporting
- [ ] File attachments

### Phase 3: Integration & Optimization (Planned)
- [ ] REST API for integrations
- [ ] Real-time updates with SignalR
- [ ] Performance optimization
- [ ] Advanced security features
- [ ] Mobile responsive enhancements

## 🤝 Contributing

This is an internal project for evaluating the feasibility of replacing the BTA portal. For questions or suggestions, please contact the development team.

## 📝 License

Internal use only - Proprietary

## 👥 Team

- Development Team: Internal DevOps and Development Teams
- Infrastructure: Azure Cloud Team
- Project Sponsor: Organization Leadership

## 📞 Support

For issues or questions about this prototype:
1. Review the [FEASIBILITY_ANALYSIS.md](FEASIBILITY_ANALYSIS.md)
2. Check the application logs
3. Contact the development team

---

**Status**: ✅ Prototype Complete - Ready for Review

**Recommendation**: PROCEED with full implementation based on this feasibility study and working prototype.
