import { useState } from 'react';
import { FaBell, FaUserCircle } from 'react-icons/fa';

const Navbar = () => {
  const [dropdownOpen, setDropdownOpen] = useState(false);

  return (
    <nav className="bg-gray-800 p-4 flex justify-between items-center shadow-md">
      <h1 className="text-white text-2xl font-bold">Admin Dashboard - Job and Internship Approval</h1>
      <div className="flex items-center space-x-6">
        {/* Notification Bell */}
        <div className="relative">
          <FaBell className="text-white text-2xl cursor-pointer hover:text-gray-400 transition-colors duration-300" />
          {/* Example of a notification badge */}
          <span className="absolute top-0 right-0 inline-flex items-center justify-center h-4 w-4 bg-red-600 text-white text-xs font-bold rounded-full">3</span>
        </div>

        {/* Profile Dropdown */}
        <div className="relative">
          <FaUserCircle
            className="text-white text-3xl cursor-pointer hover:text-gray-400 transition-colors duration-300"
            onClick={() => setDropdownOpen(!dropdownOpen)}
          />
          {dropdownOpen && (
            <ul className="absolute right-0 bg-white text-black shadow-md mt-2 w-40 rounded-lg overflow-hidden">
              <li className="p-3 hover:bg-gray-200 cursor-pointer">Account Settings</li>
              <li className="p-3 hover:bg-gray-200 cursor-pointer">Logout</li>
            </ul>
          )}
        </div>
      </div>
    </nav>
  );
};

export default Navbar;