type Props = {
  status: 'idle' | 'success' | 'error' | 'loading';
};

const ApiStatus = ({ status }: Props) => {
  switch (status) {
    case 'error':
      return <div>Error communicatingi with the datat backend</div>;
    case 'idle':
      return <div>Idle</div>;
    case 'loading':
      return <div>Loading...</div>;
    default:
      throw Error('Unknown API state');
  }
};

export default ApiStatus;
