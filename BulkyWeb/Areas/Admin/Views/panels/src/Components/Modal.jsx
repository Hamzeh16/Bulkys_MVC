const Modal = ({ post, onClose, onApprove, onReject }) => {
  // If no post is provided, do not render the modal
  if (!post) return null;

  return (
    <div className="fixed inset-0 bg-black bg-opacity-50 flex justify-center items-center z-50">
      {/* Modal container with better spacing and design improvements */}
      <div className="bg-white p-8 rounded-lg max-w-lg w-full shadow-lg relative">
        <h2 className="text-2xl font-semibold mb-4 text-blue-900">{post.title}</h2>
        <p className="mb-2">
          <strong>Company:</strong> {post.company}
        </p>
        <p className="mb-2">
          <strong>Description:</strong> {post.description}
        </p>
        <p className="mb-2">
          <strong>Location:</strong> {post.location}
        </p>
        <p className="mb-4">
          <strong>Type:</strong> {post.type}
        </p>
        <div className="flex space-x-4 mt-6 justify-end">
          <button
            className="bg-green-500 text-white px-4 py-2 rounded shadow hover:bg-green-400 transition-colors focus:outline-none focus:ring-2 focus:ring-green-400 focus:ring-offset-2"
            onClick={() => onApprove(post.id)}
          >
            Approve
          </button>
          <button
            className="bg-red-500 text-white px-4 py-2 rounded shadow hover:bg-red-400 transition-colors focus:outline-none focus:ring-2 focus:ring-red-400 focus:ring-offset-2"
            onClick={() => onReject(post.id)}
          >
            Reject
          </button>
          <button
            className="bg-gray-500 text-white px-4 py-2 rounded shadow hover:bg-gray-400 transition-colors focus:outline-none focus:ring-2 focus:ring-gray-400 focus:ring-offset-2"
            onClick={onClose}
          >
            Close
          </button>
        </div>
      </div>
    </div>
  );
};

export default Modal;