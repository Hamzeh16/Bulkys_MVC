import { FaHome, FaCheckCircle, FaTimesCircle, FaChartPie } from 'react-icons/fa';
import { NavLink } from 'react-router-dom';

const Sidebar = () => {
  return (
    <div className="bg-gray-800 h-screen w-64 flex flex-col p-4 shadow-lg">
      <div className="text-white text-2xl font-bold mb-8 text-center">Dashboard</div>
      <ul className="space-y-4">
        <li>
          <NavLink
            to="/"
            className={({ isActive }) =>
              `p-4 text-white flex items-center rounded-lg transition-colors duration-300 ${
                isActive ? 'bg-blue-600' : 'hover:bg-blue-700'
              }`
            }
            aria-label="Dashboard Overview"
          >
            <FaHome className="mr-3" />
            <span className="hidden md:inline">Dashboard Overview</span>
          </NavLink>
        </li>
        <li>
          <NavLink
            to="/pending-approvals"
            className={({ isActive }) =>
              `p-4 text-white flex items-center rounded-lg transition-colors duration-300 ${
                isActive ? 'bg-yellow-600' : 'hover:bg-yellow-700'
              }`
            }
            aria-label="Pending Approvals"
          >
            <FaCheckCircle className="mr-3" />
            <span className="hidden md:inline">Pending Approvals</span>
          </NavLink>
        </li>
        <li>
          <NavLink
            to="/approved-posts"
            className={({ isActive }) =>
              `p-4 text-white flex items-center rounded-lg transition-colors duration-300 ${
                isActive ? 'bg-green-600' : 'hover:bg-green-700'
              }`
            }
            aria-label="Approved Posts"
          >
            <FaCheckCircle className="mr-3" />
            <span className="hidden md:inline">Approved Posts</span>
          </NavLink>
        </li>
        <li>
          <NavLink
            to="/rejected-posts"
            className={({ isActive }) =>
              `p-4 text-white flex items-center rounded-lg transition-colors duration-300 ${
                isActive ? 'bg-red-600' : 'hover:bg-red-700'
              }`
            }
            aria-label="Rejected Posts"
          >
            <FaTimesCircle className="mr-3" />
            <span className="hidden md:inline">Rejected Posts</span>
          </NavLink>
        </li>
        <li>
          <NavLink
            to="/analytics"
            className={({ isActive }) =>
              `p-4 text-white flex items-center rounded-lg transition-colors duration-300 ${
                isActive ? 'bg-purple-600' : 'hover:bg-purple-700'
              }`
            }
            aria-label="Analytics"
          >
            <FaChartPie className="mr-3" />
            <span className="hidden md:inline">Analytics</span>
          </NavLink>
        </li>
      </ul>
    </div>
  );
};

export default Sidebar;