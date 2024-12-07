import { useState } from 'react';

// Component to display a table of job posts that need approval.
// It provides actions for approving, rejecting, and viewing details of each job post.
const ApprovalTable = ({ posts, onApprove, onReject, onViewDetails }) => {
  return (
    <table className="min-w-full bg-white border-collapse border border-gray-300">
      <thead className="bg-gray-100">
        <tr>
          <th className="py-2 px-4 border border-gray-300">Job Title</th>
          <th className="py-2 px-4 border border-gray-300">Company Name</th>
          <th className="py-2 px-4 border border-gray-300">Posting Date</th>
          <th className="py-2 px-4 border border-gray-300">Type</th>
          <th className="py-2 px-4 border border-gray-300">Actions</th>
        </tr>
      </thead>
      <tbody>
        {posts.length > 0 ? (
          posts.map((post) => (
            <tr key={post.id} className="text-center hover:bg-gray-50 transition-colors">
              <td className="py-2 px-4 border border-gray-300">{post.title}</td>
              <td className="py-2 px-4 border border-gray-300">{post.company}</td>
              <td className="py-2 px-4 border border-gray-300">{post.date}</td>
              <td className="py-2 px-4 border border-gray-300">{post.type}</td>
              <td className="py-2 px-4 border border-gray-300">
                <button
                  className="bg-green-500 text-white px-2 py-1 rounded mr-2 hover:bg-green-400 transition-colors"
                  onClick={() => onApprove(post.id)}
                >
                  Approve
                </button>
                <button
                  className="bg-red-500 text-white px-2 py-1 rounded mr-2 hover:bg-red-400 transition-colors"
                  onClick={() => onReject(post.id)}
                >
                  Reject
                </button>
                <button
                  className="bg-blue-500 text-white px-2 py-1 rounded hover:bg-blue-400 transition-colors"
                  onClick={() => onViewDetails(post)}
                >
                  View Details
                </button>
              </td>
            </tr>
          ))
        ) : (
          <tr>
            <td colSpan="5" className="py-4 text-center text-gray-500">
              No job posts available for approval.
            </td>
          </tr>
        )}
      </tbody>
    </table>
  );
};

export default ApprovalTable;